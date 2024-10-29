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
        // Cursor l�ses och blir osynlig n�r man anv�nder kameran
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPosition;
    }

    
    void Update()
    {
        //Styr kameran. Man skapar sjyssta inputv�rden, multiplicerade med tid och sensitivity s� vi f�r kameran tidsberoende och g�r att styra
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // Denna f�rhindrar att kameran v�nder sig uppochned
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // S�tter kamera och karakt�rs rotation
        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);

        // Flytta p� kameran, eller, jah, emptyn, antar jag?
        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = Vector3.Lerp(camera.position, cameraTargetPosition, 0.5f);
    }
}
