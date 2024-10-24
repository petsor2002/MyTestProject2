using UnityEngine;

public class PivotCamera : MonoBehaviour
{
    // Sensitivity variables
    public float sensX = 500f;
    public float sensY = 500f;

    public float smoothTime = 0.1f;

    // Private variables, our targets for the camera
    float xTarget;
    float yTarget;

    float xCurrent;
    float yCurrent;

    float xCurrentVelocity;
    float yCurrentVelocity;


    void Start()
    {
        // Vi vill inte att kameran b�rjar med att balla ur
        xTarget = xCurrent;
        yTarget = yCurrent;
    }

    
    void Update()
    {
        // Vi multiplicerar musens position med Tid, f�r at den skall g� p� tid ist�llet f�r FPS, och med v�r Sensitivityvariabel. 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // N�r musens knapp trycks ned s� vill vi att pekaren blir osynlig, inte r�r sig och vi kan �ndra variablerna f�r kamerans position
        if (Input.GetMouseButton(0))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            xTarget += mouseX;
            yTarget += mouseY;
        }
        else
        // Annars vill vi att den beter sig normalt. 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // D�mparfunktionen SmoothDamp anv�nder target och current f�r att r�kna ut var kameran �r och vart den borde r�ra sig. 
        xCurrent = Mathf.SmoothDamp(xCurrent, xTarget, ref xCurrentVelocity, smoothTime);
        yCurrent = Mathf.SmoothDamp(yCurrent, yTarget, ref yCurrentVelocity, smoothTime);

        // S�tt kamerans transform-properties till v�ra variabler. 
        transform.eulerAngles = new Vector3(-yCurrent, xCurrent, 0f);
    }
}
