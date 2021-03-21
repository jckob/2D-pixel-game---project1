using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    public GameObject Light;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D = null;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D2 = null;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D3 = null;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D4 = null;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D5 = null;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D6 = null;

    void Start()
    {
       
        
    }


    void Update()
    {
        Input.GetKey(KeyCode.F);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
           
        }
        
    }

    IEnumerator Teleport()
    {

        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
        light2D.enabled = true;
        light2D2.enabled = true;
        light2D3.enabled = true;
        light2D4.enabled = true;
        light2D5.enabled = true;
        light2D6.enabled = true;


    }
}
