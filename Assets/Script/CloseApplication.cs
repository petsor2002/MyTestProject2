using UnityEngine;

public class CloseApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Close the application
            Debug.Log("Application is closing...");
            Application.Quit();


        }
    }
}

