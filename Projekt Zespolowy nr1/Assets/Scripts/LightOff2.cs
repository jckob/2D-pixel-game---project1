using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff2 : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    public GameObject Light;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D2;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D3;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D4;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D5;
    [SerializeField]
    UnityEngine.Experimental.Rendering.Universal.Light2D light2D6;

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
        light2D.enabled = false;
        light2D2.enabled = false;
        light2D3.enabled = false;
        light2D4.enabled = false;
        light2D5.enabled = false;
        light2D6.enabled = false;


    }
}
