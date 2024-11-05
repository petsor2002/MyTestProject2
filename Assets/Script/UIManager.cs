using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    public Canvas edisplay;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    public void ShowCanvas(bool show)
    {
        edisplay.gameObject.SetActive(show);
    }
}
