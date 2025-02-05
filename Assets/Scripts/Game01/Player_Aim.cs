using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player_Aim : MonoBehaviour
{
    //Instanciacion
    InputSystem_Actions playerInputs;
    //Aim Variables
    private Camera mainCamera;
    private Vector2 aimPos;
    //Attack Variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletRate;
    private float nextshot;
    //public float Nextshot { get { return nextshot; } }
    private bool isAttack = false;
    //public bool IsAttack { get { return isAttack;}}
    //Audio Variable
    private AudioSource audioShoot;

    private void Awake() {
        mainCamera = Camera.main;
        playerInputs = new InputSystem_Actions();

        playerInputs.Player.Look.performed += ctx => aimPos = ctx.ReadValue<Vector2>();
        playerInputs.Player.Attack.started += OnAttackInput;
        playerInputs.Player.Attack.canceled += OnAttackInput;
    }
    private void Start() {
        audioShoot = GetComponentInChildren<AudioSource>();
    }
    private void Update() {
        AimRotation();
        if (isAttack && Time.time >= nextshot) {
            Shoot();
            nextshot = Time.time + bulletRate;
        }
        
    }
    /*void OnAimInput (InputAction.CallbackContext context) {
        aimPosInput = context.ReadValue<Vector2>();
        aimPos.x = aimPosInput.x;
        aimPos.y = aimPosInput.y;
    }*/
    void OnAttackInput (InputAction.CallbackContext context) {
        isAttack = context.ReadValueAsButton();
    }
    private void AimRotation() {
        //posicion del mouse en coordenadas
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(aimPos);
        mousePos.z = 0f;
        //calcular direccion hacia el mouse
        Vector2 dir = (mousePos - transform.position).normalized;
        //rotar al objeto
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void Shoot() {
        if(!isAttack) return;
        //crear proyectil y asignar direccion
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //reproduce el sfx
        audioShoot.Play();
        //la bala se mueve a donde apunta
        if(rb != null && isAttack) rb.linearVelocity = firePoint.right * bulletSpeed;
    }
    private void OnEnable() {
        playerInputs.Player.Enable();
    }
    private void OnDisable() {
        playerInputs.Player.Disable();
    }
}
