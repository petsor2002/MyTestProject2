using UnityEngine;

public class BatMover : MonoBehaviour
{
    public float batSpeed = 10f;
    public float swoopSpeed = 15f;
    public float batStartAngle = 30.0f;

    float batTime;
    float batAngle;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Spawn bat, or, well, activate game object? Instantiate?
        //ToggleGameObject via Trigger
        batAngle = batStartAngle; 
        
    }

    // Update is called once per frame
    void Update()
    {
        batTime += Time.deltaTime * batSpeed;
        batAngle -= Time.deltaTime * swoopSpeed * batSpeed; 


        transform.localRotation = Quaternion.AngleAxis(batAngle, Vector3.right);



        //Move bat by updating it's local position relating to it's local z-direction
        Vector3 localForward = transform.localRotation * Vector3.forward;

        transform.localPosition += localForward * batSpeed * Time.deltaTime;

        //Adjust bat's local rotation to follow a pattern

        //despawn bat after 2s. 
    }
}
