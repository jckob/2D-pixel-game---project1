using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightfollow : MonoBehaviour
{
    public GameObject Light;
    
    void Start()
    {


        
    }

    
    void Update()
    {
        Light.transform.position = new Vector3(0.5f, 0, 0);
        
    }
}
