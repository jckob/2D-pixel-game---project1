using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        Input.GetKey(KeyCode.F);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
                StartCoroutine(Teleport());  
        }
    }
    
    IEnumerator Teleport()
    {

        yield return new WaitForSeconds(0.5f);
            Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
        
    }
}
