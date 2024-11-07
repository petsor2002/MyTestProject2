using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    public Canvas edisplay;

    public List<WhosGraveisThis> signs = new List<WhosGraveisThis>();

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        bool show = false;
        foreach(WhosGraveisThis sign in signs)
        {
            if (sign.playerReading)
                show = true;
        }

        edisplay.gameObject.SetActive(show);
    }
}
