using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] private float str = 5;
    [SerializeField] private float random = 0.01f;
    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForceAtPosition(Vector3.up * str, Random.insideUnitSphere * random, ForceMode.Impulse);
        }
    }
}
