using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject Player;
    public GameObject Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Player)
        {
            FindObjectOfType<AudioManager>().Play("enemyDMGSound");
            health -= 1;
            
        }
        if(health == 0)
        {
            FindObjectOfType<AudioManager>().Play("enemyDeathSound");
            OnDestroy();
        }
        
        
            
        
    }
    private void OnDestroy()
    {
        Destroy(this.gameObject);
        Enemy.GetComponent<CircleCollider2D>().enabled = false;
    }




}
