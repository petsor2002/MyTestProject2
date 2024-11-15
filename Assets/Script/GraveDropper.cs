using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GraveDropper : MonoBehaviour
{
    public float waitTime = 2f;
    public UnityEvent wilhelmScream;
    // private AudioSource wilhelmScream;

    void Start()
    {
        //wilhelmScream = GetComponent<AudioSource>();
    }

    public void StartTheToggler()
    {
        StartCoroutine(ToggleActive());
        wilhelmScream.Invoke();

        //wilhelmScream.Play();
    }
    public IEnumerator ToggleActive()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(!gameObject.activeSelf);
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(!gameObject.activeSelf);


    }
}
