using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseMove;
    private Rigidbody rb;
    public float sens = 100f;
    public Transform cameraPivot;
    private float xRotation = 0f;


    public Rigidbody bullet;
    public Rigidbody bulletrb;
    public Transform muzzle;
    public BulletPool pool;
    public float bulletSpeed = 100f;

    


    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Walk();
    }

    void Update()
    {
        Mouse();
    }

    void Walk()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 targetPosition = rb.position + move * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    void Mouse()
    {
        float mouseX = mouseMove.x * sens * Time.deltaTime;
        float mouseY = mouseMove.y * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -100f, 100f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnMouse(InputAction.CallbackContext context)
    {
        mouseMove = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            speed = (float)(speed * 2);
        }
        if(context.canceled)
        {
            speed = (float)(speed / 2);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
        
    }

    

    public void Shoot()
{   
    Debug.Log("Shoot");
    Audio.instance.PlayShoot();

    Rigidbody rb = pool.GetBullet();

    rb.transform.position = muzzle.position + muzzle.forward * 0.5f;
    rb.transform.rotation = muzzle.rotation;

    rb.gameObject.SetActive(true);

    rb.linearVelocity = Vector3.zero; // reset old move
    rb.angularVelocity = Vector3.zero;

    rb.AddForce(muzzle.forward * bulletSpeed, ForceMode.Impulse);
}

}