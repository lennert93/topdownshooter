using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class menuManager : MonoBehaviour
{
    GameObject restartPanel;
    public delegate void menuEvent();
    public static event menuEvent dieEvent;
    // Start is called before the first frame update
    void Start()
    {
        dieEvent += () => { setRestartMenu(); };
    }

    public void setRestartMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        restartPanel.SetActive(true);
    }
}
