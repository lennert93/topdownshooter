using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletinfo : MonoBehaviour
{
    public float gunpower;
    public float autoDestory = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, autoDestory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
