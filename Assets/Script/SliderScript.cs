using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{
    public Slider slider;


    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(slider.value);
    }
}
