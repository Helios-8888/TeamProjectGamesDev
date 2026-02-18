using InteractableItems;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Supermarket.IPlayerActions
{

    [Header("Movement")]
    private Rigidbody _RB;
    private Vector2 _InputDir;
    private Vector3 _ViewDir;
    public bool Grounded;
    public float MoveSpeed;
    public float JumpForce;
    public float GroundFriction = 5f;
    public float AirFriction = 0f;
    public Transform CameraTransform;
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    TextMeshProUGUI interactableText;

    [SerializeField]
    float interactbaleDistance = 5f;

    IInteractable currentTargetedInteractable;

    Inventory playerInventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerInventory = GetComponent<Inventory>();    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentInteractable();

        UpdateInteractableText();

        if (Grounded)
        {
            _RB.linearDamping = GroundFriction; //When grounded apply friction to the player
        }
        else
        {
            _RB.linearDamping = AirFriction; //When airborne reduce friction to a lower value
        }

        //Adjust player rotation with look direction
        Vector3 vectorBetween = transform.position - CameraTransform.position;
        float angle = Mathf.Acos(Vector3.Dot(Vector3.forward, vectorBetween.normalized)) * Mathf.Rad2Deg;
        if (vectorBetween.x < 0)
        {
            angle *= -1;
        }
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = rotation;
    }

    private void FixedUpdate()
    {
        if (Grounded)
        {
            MovePlayer(_InputDir);
        }
    }

    void MovePlayer(Vector3 direction)
    {
        Vector3 movementDirection = CameraTransform.forward * direction.y + CameraTransform.right * direction.x;
        movementDirection.y = 0;
        _RB.AddForce(movementDirection * MoveSpeed, ForceMode.VelocityChange); //Do not directly modify velocity. Rb.Add Force is much better as long as you change the friction values (as I did above)
    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _InputDir = context.ReadValue<Vector2>();

        //If we add animations, throw something else in here
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        //Just for testing
        if (context.performed)
        {
            if (TryGetComponent<EntityHealth>(out EntityHealth health))
            {
                health.DamageHP(15);
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started && currentTargetedInteractable != null)
        {
            currentTargetedInteractable.Interact();
            playerInventory.AddItem(currentTargetedInteractable.interactableName);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump Pressed");
            if (Grounded)
            {
                _RB.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);

            }
        }
    }
    void UpdateCurrentInteractable()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactbaleDistance);

        currentTargetedInteractable = hit.collider?.GetComponent<IInteractable>();

    }

    void UpdateInteractableText()
    {
        if (currentTargetedInteractable == null)
        {
            interactableText.text = string.Empty;
            return;
        }

        interactableText.text = currentTargetedInteractable.InteractableMessage;
    }


public void OnCrouch(InputAction.CallbackContext context)
    {
    }


    public void OnPrevious(InputAction.CallbackContext context)
    {
    }

    public void OnNext(InputAction.CallbackContext context)
    {
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Grounded = false;
        }
    }
}
