using UnityEngine;

public class MoveThirdPerson : MonoBehaviour
{
    Rigidbody rb;

    public new Transform camera;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 600f;

    [Header("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;
    bool grounded;

    void Start()
    {
        // Frys rb s� fysikmotor inte p�verkar
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        //h�mta WASD
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        // L�gg till hastigheten till vektorn f�r den nya positionen

        Vector3 forwardVector = new Vector3(camera.forward.x, 0f, camera.forward.z).normalized;
        Vector3 rightVector = new Vector3(camera.right.x, 0f, camera.right.z).normalized;

        Vector3 moveVector = (forwardVector * vInput) + (rightVector * hInput);

        // Avoid speedy sqrt(2) iagonals
        if (moveVector.magnitude > 1)
            moveVector = moveVector.normalized;

        moveVector = moveVector.normalized * moveSpeed;
        
        // Kolla om karakt�ren st�r p� marken �r sant. Detta genom att vi Raycastar rakt ned, lite l�ngre �n halva karakt�rsh�jden, och ser om vi tr�ffar Ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);

        // Rita ut Raycasten, s� man ser den. Om Grounded, then Gr�n, annars r�d
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (grounded)
            Debug.DrawRay(transform.position, Vector3.down, Color.green);

        // Spara den vertikala hastigheten i en variabel
        float verticalSpeed = rb.linearVelocity.y;

        // Om man �r p� marken uppdatera vektorn s� man r�r sig och om p� marken, hoppa med Mellanslag. 
        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
                verticalSpeed = 20;
            rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);
        }
        //rotera spelaren
        if (moveVector.magnitude > 0.2f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
