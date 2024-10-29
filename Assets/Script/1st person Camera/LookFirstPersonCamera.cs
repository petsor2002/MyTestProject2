using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class LookFirstPersonCamera : MonoBehaviour
{
    
    //Sensitivityvariabler
    public float sensX = 500f;
    public float sensY = 500f;

    public new Transform camera;
    public float eyeHeight = 1f;

    //Privata variabler

    float xRotation;
    float yRotation;



    void Start()
    {
        // Cursor låses och blir osynlig när man använder kameran
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPosition;
    }

    
    void Update()
    {
        //Styr kameran. Man skapar sjyssta inputvärden, multiplicerade med tid och sensitivity så vi får kameran tidsberoende och går att styra
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // Denna förhindrar att kameran vänder sig uppochned
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Sätter kamera och karaktärs rotation
        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);

        // Flytta på kameran, eller, jah, emptyn, antar jag?
        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = Vector3.Lerp(camera.position, cameraTargetPosition, 0.5f);
    }
}
