using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class MoveFirstPersonCamera : MonoBehaviour
{
    // Referens till den rigidbodykompnent som ingår i karaktären
    Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("GroundCheck")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;
    bool grounded;

    void Start()
    {
        // fryser karaktärens rigidbody, så inte grafikmotorn håller på och snurrar på den
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        //hämta WASD
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        // Skapa vektor som beskriver hur mycket vi rör oss. Lägg till hastigheten till vektorn för den nya positionen
        Vector3 moveVector = (transform.forward * vInput) + (transform.right * hInput);

        // normalisera vektorn för att få ut en vektor som är högst 1 lång, annars blir diagonalerna sqrt(2) snabbare
        if (moveVector.magnitude > 1f)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        // Kolla om karaktären står på marken är sant. Detta genom att vi Raycastar rakt ned, lite längre än halva karaktärshöjden, och ser om vi träffar Ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);

        // Rita ut Raycasten, så man ser den. Om Grounded, then Grön, annars röd
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (grounded)
            Debug.DrawRay(transform.position, Vector3.down, Color.green);

        // Spara den vertikala hastigheten i en variabel
        float verticalSpeed = rb.linearVelocity.y;

        // Om man är på marken uppdatera hastighetsvektorn och, om på marken; hoppa med Mellanslag. 
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
