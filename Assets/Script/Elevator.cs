using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 3f;
    public float targetHeight = 10f;

    //private variables

    Vector3 startPosition;

    bool reachTarget;


    void Start()
    {
        startPosition = transform.position;

    }

    void Update()
    {
        if (reachTarget)
        {
            Vector3 targetPosition = new Vector3(startPosition.x, targetHeight, startPosition.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }

    }

    public void ToggleReachTarget()
    {

        reachTarget = !reachTarget;
    }
}
