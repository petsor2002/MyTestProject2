using System.Collections;
using UnityEngine;

public class GraveDropper : MonoBehaviour
{
    public float waitTime = 2f;

    public void StartTheToggler()
    {
        StartCoroutine(ToggleActive());
    }
    public IEnumerator ToggleActive()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
