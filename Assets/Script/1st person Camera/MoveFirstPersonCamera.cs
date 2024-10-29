using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class MoveFirstPersonCamera : MonoBehaviour
{
    // Referens till den rigidbodykompnent som ing�r i karakt�ren
    Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("GroundCheck")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;
    bool grounded;

    void Start()
    {
        // fryser karakt�rens rigidbody, s� inte grafikmotorn h�ller p� och snurrar p� den
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        //h�mta WASD
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        // Skapa vektor som beskriver hur mycket vi r�r oss. L�gg till hastigheten till vektorn f�r den nya positionen
        Vector3 moveVector = (transform.forward * vInput) + (transform.right * hInput);

        // normalisera vektorn f�r att f� ut en vektor som �r h�gst 1 l�ng, annars blir diagonalerna sqrt(2) snabbare
        if (moveVector.magnitude > 1f)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        // Kolla om karakt�ren st�r p� marken �r sant. Detta genom att vi Raycastar rakt ned, lite l�ngre �n halva karakt�rsh�jden, och ser om vi tr�ffar Ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);

        // Rita ut Raycasten, s� man ser den. Om Grounded, then Gr�n, annars r�d
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (grounded)
            Debug.DrawRay(transform.position, Vector3.down, Color.green);

        // Spara den vertikala hastigheten i en variabel
        float verticalSpeed = rb.linearVelocity.y;

        // Om man �r p� marken uppdatera hastighetsvektorn och, om p� marken; hoppa med Mellanslag. 
        if (grounded) { 
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = 12;
                
            }
            rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);


        }
        else
        {
            rb.linearVelocity = new Vector3(moveVector.x*1f, verticalSpeed, moveVector.z*1f);
        }

      

        
    }
}
