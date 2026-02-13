using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyAIController : MonoBehaviour
{
    public enum State { Patrol, Chase, Search }
    [Header("State (read-only)")]
    [SerializeField] private State state = State.Patrol;

    [Header("References")]
    [SerializeField] private Transform player; // assign in Inspector, OR use Player tag
    [SerializeField] private Transform[] patrolPoints;

    [Header("Movement")]
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float arriveDistance = 0.6f;
    [SerializeField] private bool faceMovementDirection = true;

    [Header("Vision")]
    [SerializeField] private float viewRadius = 10f;
    [Range(0, 360)]
    [SerializeField] private float viewAngle = 90f;
    [SerializeField] private float eyeHeight = 1.6f;
    [SerializeField] private LayerMask targetMask;   // set to Player layer
    [SerializeField] private LayerMask obstacleMask; // set to Walls/Obstacles layer

    [Header("Chase / Search")]
    [SerializeField] private float stopDistance = 1.2f;
    [SerializeField] private float loseSightGraceSeconds = 2.0f; // memory
    [SerializeField] private float searchDurationSeconds = 3.0f;

    private Rigidbody rb;
    private int patrolIndex = 0;

    private float lastTimeSawPlayer = -999f;
    private Vector3 lastSeenPosition;
    private float searchTimer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (!player)
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
        }
    }

    private void Update()
    {
        bool canSeePlayer = CanSeePlayer(out Vector3 seenPos);

        if (canSeePlayer)
        {
            lastTimeSawPlayer = Time.time;
            lastSeenPosition = seenPos;
            state = State.Chase;
        }
        else
        {
            // memory window: keep chasing briefly after losing line-of-sight
            bool withinMemory = Time.time - lastTimeSawPlayer <= loseSightGraceSeconds;

            if (state == State.Chase && !withinMemory)
            {
                state = State.Search;
                searchTimer = searchDurationSeconds;
            }

            if (state == State.Search)
            {
                searchTimer -= Time.deltaTime;
                if (searchTimer <= 0f)
                    state = State.Patrol;
            }
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Patrol:
                PatrolMove();
                break;

            case State.Chase:
                ChaseMove();
                break;

            case State.Search:
                SearchMove();
                break;
        }
    }

    // -------------------------
    // STATES
    // -------------------------

    private void PatrolMove()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            //Idle
            return;
        }

        Transform target = patrolPoints[patrolIndex];
        MoveTowards(target.position, patrolSpeed);

        if (Vector3.Distance(Flatten(transform.position), Flatten(target.position)) <= arriveDistance)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void ChaseMove()
    {
        if (!player)
        {
            state = State.Patrol;
            return;
        }

        float dist = Vector3.Distance(Flatten(transform.position), Flatten(player.position));
        if (dist <= stopDistance)
        {
            //Enemy has reached the position
            return;
        }

        MoveTowards(player.position, chaseSpeed);
    }

    private void SearchMove()
    {
        // Move to last seen position; once you arrive, just look around (optional)
        float dist = Vector3.Distance(Flatten(transform.position), Flatten(lastSeenPosition));

        if (dist > arriveDistance)
        {
            MoveTowards(lastSeenPosition, patrolSpeed);
        }
        else
        {

            // Optional: rotate slowly while searching
            transform.Rotate(0f, 90f * Time.fixedDeltaTime, 0f);
        }
    }

    // -------------------------
    // VISION
    // -------------------------

    private bool CanSeePlayer(out Vector3 playerPos)
    {
        playerPos = Vector3.zero;
        if (!player) return false;

        Vector3 eyePos = transform.position + Vector3.up * eyeHeight;

        // Distance check (fast)
        Vector3 toPlayer = player.position - eyePos;
        float distToPlayer = toPlayer.magnitude;
        if (distToPlayer > viewRadius) return false;

        // Optional: ensure player is on the targetMask layer
        // (This check is helpful if you use many colliders around the player.)
        if (((1 << player.gameObject.layer) & targetMask) == 0) return false;

        // Angle check (FOV cone)
        Vector3 dirToPlayer = toPlayer.normalized;
        if (Vector3.Angle(transform.forward, dirToPlayer) > viewAngle * 0.5f) return false;

        // Line-of-sight (raycast)
        if (Physics.Raycast(eyePos, dirToPlayer, out RaycastHit hit, distToPlayer, obstacleMask))
        {
            // Something blocked the view
            return false;
        }

        // Clear sight
        playerPos = player.position;
        return true;
    }

    // -------------------------
    // MOVEMENT HELPERS
    // -------------------------

    private void MoveTowards(Vector3 worldTarget, float speed)
    {
        Vector3 current = transform.position;
        Vector3 targetFlat = Flatten(worldTarget);
        Vector3 currentFlat = Flatten(current);

        Vector3 dir = (targetFlat - currentFlat);
        dir.Normalize();

        // Smooth turn
        if (faceMovementDirection)
        {
            Quaternion desiredRot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, turnSpeed * Time.fixedDeltaTime);
        }

        Vector3 vel = dir * speed;
        rb.AddForce(vel, ForceMode.VelocityChange); //Do not directly modify velocity. Rb.Add Force is much better as long as you change the friction values (as I did above)

        //rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
    }


    private static Vector3 Flatten(Vector3 v) => new Vector3(v.x, 0f, v.z);

    // -------------------------
    // DEBUG DRAW (Scene view)
    // -------------------------
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 left = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward;
        Vector3 right = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + left * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + right * viewRadius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(lastSeenPosition, 0.2f);
    }
}
