using UnityEngine;

public class BatWingFlap : MonoBehaviour
{
    public bool mirrorWing = false;
    public float flapSpeed = 30f;
    public float flapAngle = 55.0f;
    private float flapTime = 0f;


    // Update is called once per frame
    void Update()
    {
        flapTime += Time.deltaTime * flapSpeed;

        float angle = Mathf.Sin(flapTime) * flapAngle;

        if (mirrorWing)
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
        else
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 180.0f - angle);



    }
}
