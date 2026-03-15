using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, Supermarket.IPlayerActions
{
    [Header ("Entity Health")]
    private EntityHealth _Health;

    [Header("Movement")]
    private Rigidbody _RB;
    private Vector2 _InputDir;
    private Vector3 _ViewDir;

    [Header("Physics Variables")]
    public bool Grounded; //True if the player is on the ground
    public bool HasShoppingTrolley; // True if the player has the Shopping Trolley equipped.
    public float CurrentSpeed = 0f;
    public float WalkSpeed = 2f;
    public float TrolleySpeed = 1.5f;
    public float JumpForce = 5f;
    public float WalkingFriction = 5f;
    public float TrolleyFriction = 3f;
    public float AirFriction = 0f;

    [Header("Attach in Inspector")]
    public Transform CameraTransform;
    public Bullet Bullet;
    public Transform bulletspawn;
    public GameObject TrolleyPrefab;
    public Transform TrolleyAttachment;
    public PlayerData PlayerData;
    public ShoppingListUI ShoppingListUI;

    [Header("Inventory Items")]
    public InteractableItem currentTargetedInteractable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _RB = GetComponent<Rigidbody>();
        _Health = GetComponent<EntityHealth>();
        PlayerData = GetComponent<PlayerData>();
        PlayerData.SetupPlayerData();

        CurrentSpeed = WalkSpeed;
    }



    // Update is called once per frame
    void Update()
    {
        if (Grounded)
        {
            //When grounded apply friction to the player
            if (HasShoppingTrolley)
            {
                _RB.linearDamping = TrolleyFriction; //Less friction when shopping Trolley Equipped
            }
            else

            {
                _RB.linearDamping = WalkingFriction; //More Friction when walking normally
            }
        }
        else
        {
            _RB.linearDamping = AirFriction; //Player is frictionless when airborne
        }

        //Adjust player rotation with look direction 
        float CameraYAngle = CameraTransform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, CameraYAngle, 0);
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
        _RB.AddForce(movementDirection * CurrentSpeed, ForceMode.VelocityChange); //Do not directly modify velocity. Rb.Add Force is much better as long as you change the friction values (as I did above)
    
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
            if (Bullet != null)
            {
                Bullet bulletInstance = Instantiate(Bullet, bulletspawn.position + CameraTransform.forward *2f, Quaternion.identity);
                bulletInstance.ShootBullet(CameraTransform.forward, _Health);
                
            }
            else
                {
                    Debug.LogError("Bullet prefab is not assigned or has been destroyed.");
                }
           
            
            
            
                
            
       }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RaycastHit hit;
            if (Physics.Raycast(bulletspawn.position, CameraTransform.forward, out hit, 5f))
            {
                Debug.DrawRay(bulletspawn.position, CameraTransform.forward * 5f, Color.blue);
                if (hit.collider.gameObject.TryGetComponent<InteractableItem>(out InteractableItem item))
                {
                    currentTargetedInteractable = item;
                    if (PlayerData.Pennies >= item.ItemCost)
                    {
                        PlayerData.PlayerInventory.AddItem(currentTargetedInteractable);
                        Debug.Log(item.itemName);
                        PlayerData.Pennies-=item.ItemCost;
                        if (item.itemName == "Shopping Trolley")
                        {
                                HasShoppingTrolley = true;
                                GameObject newTrolley = Instantiate(TrolleyPrefab, TrolleyAttachment.position, transform.rotation);
                                newTrolley.transform.parent = bulletspawn;
                                CurrentSpeed = TrolleySpeed;
                        }
                        Destroy(item.gameObject);
                    }
                    else
                    {
                        Debug.Log($"Can't afford the current item: {item.itemName} ({PlayerData.Pennies} / {item.ItemCost})");
                    }
                    item.Interact();
                }

            }
            
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump Pressed");
            if (Grounded)
            {
                if ( HasShoppingTrolley)
                {
                    //Release the shoppping trolley? Could also just prevent jumping
                }
                else
                {
                    //Allow player to jump when not holding the shoppping trolley
                    _RB.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);

                }

            }
        }
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

    public void OnOpenShoppingList(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Shopping list toggled"); 
            ShoppingListUI.Toggle();
        }
    }
}
