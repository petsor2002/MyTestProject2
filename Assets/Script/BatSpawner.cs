using System.Collections;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject prefab;
    //public bool spamBats = false;
    public float timeDelay = 0.1f;
    public int numberOfBats = 10;
    public float timeToLive = 0.5f;

    public Vector3 positionOffsetRange = new Vector3(0.5f, 0.5f, 0.5f);  // Random position offset range
    public Vector3 rotationOffsetRange = new Vector3(10f, 10f, 10f);  // Random rotation offset range (in degrees)



    void Start()
    {
        
    }

    IEnumerator SpawnSomeBats()
    {


        for (int i = 0; i < numberOfBats; i++)
        {
            // Skapa offsets och rotationsvariationer
            Vector3 randomPositionOffset = new Vector3(
                Random.Range(-positionOffsetRange.x, positionOffsetRange.x),
                Random.Range(-positionOffsetRange.y, positionOffsetRange.y),
                Random.Range(-positionOffsetRange.z, positionOffsetRange.z)
            );

            Quaternion randomRotationOffset = Quaternion.Euler(
                Random.Range(-rotationOffsetRange.x, rotationOffsetRange.x),
                Random.Range(-rotationOffsetRange.y, rotationOffsetRange.y),
                Random.Range(-rotationOffsetRange.z, rotationOffsetRange.z)
            );

            // Skapa randomiserade startpositioner
            Vector3 spawnPosition = transform.position + randomPositionOffset;
            Quaternion spawnRotation = transform.rotation * randomRotationOffset;

            GameObject bat = Instantiate(prefab, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(timeDelay);

            Destroy(bat, timeToLive);



        }
    }

    // void Update()
    //{
      //  if (spamBats)
        //{
          //  GameObject cloneBat = Instantiate(prefab);

            //cloneBat.transform.position = transform.position;
            //cloneBat.transform.rotation = transform.rotation;

            //Lägg till jitter, så de flyger olika

            //Lägg till paus mellan spawns

            // lägg till Destroy after 2 s.
       // }
        
        
   // }

    public void ToggleBats() 
    {

        StartCoroutine(SpawnSomeBats());
     

    }



}
