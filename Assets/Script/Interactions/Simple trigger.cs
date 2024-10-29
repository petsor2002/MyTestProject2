using UnityEngine;
using UnityEngine.Events;

public class Simpletrigger : MonoBehaviour
{
    public bool destroyOnTrigger;
    
    public string tagFilter;

    // skapa boxarna i simpletrigger
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    void OnTriggerEnter(Collider other)
    {
        //filtrera alla objekt som kan gå in i triggern till att bara vara det vi skriver in i funktionens Filter (Player-typen av objekt)
        if (other.CompareTag(tagFilter))
        {
            // gör det som står i On Trigger Enter
            onTriggerEnter.Invoke();

      
        }    
        

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {

            onTriggerExit.Invoke();
            // tar bort triggern, om icheckad, så den bara triggas en gång
            if (destroyOnTrigger)
                Destroy(gameObject);

        }
    }
}
