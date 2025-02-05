using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    //Intanciacion
    InputSystem_Actions playerInputs;
    private Camera mainCamera;

    //Move Variables
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 currentMovementInput;
    private Vector2 currentMovement;

    //Restricciones Variables
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;
    //private Vector2 moveInput;
    //private bool isMovementPressed;
    //Player variables
    private Rigidbody2D rb;
    //[SerializeField] private int life = 3; /// PARA LA VIDA
    
    private void Awake() {
        playerInputs = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();

        playerInputs.Player.Move.started += OnMovementInput;
        playerInputs.Player.Move.canceled += OnMovementInput;
        playerInputs.Player.Move.performed += OnMovementInput;
    }
    private void Start() {
        mainCamera = Camera.main;
        PlayerBounds();
    }
    private void Update() {
        rb.linearVelocity = currentMovement * moveSpeed;

    }
    void OnMovementInput(InputAction.CallbackContext context) {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.y = currentMovementInput.y;
        //isMovementPressed = currentMovementInput.x !=0 || currentMovementInput.y !=0;
    }
    private void PlayerBounds() {
        //Calcular limites
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        SpriteRenderer render = GetComponent<SpriteRenderer>();
        if (render != null) {
            playerWidth = render.bounds.size.x / 2f;
            playerHeight = render.bounds.size.y / 2f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bubble") {
            GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
            gameManager.LoseLife();
            //LifeManager.Instance.LoseLife();
            //life--;
        }
    }
    private void LateUpdate() {
        Vector3 pos = transform.position;
        pos.x = math.clamp(pos.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        pos.y = math.clamp(pos.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight);
        transform.position = pos;
    }
    private void OnEnable() {
        playerInputs.Player.Enable();
    }
    private void OnDisable() {
        playerInputs.Player.Disable();
    }
}
