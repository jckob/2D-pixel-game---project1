using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts; //[0] [1] [2]
    public int life;    //3
    private bool dead;
    public string script;
    public int MaxLife;
    public GameObject audio1;
    public GameObject audio2;
    public GameObject DeathScreen;
    


    private void Start()
    {
        life = hearts.Length;
        MaxLife = life;
        
    }


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.tag == "Enemy")

        {
            FindObjectOfType<AudioManager>().Play("auuChracterSound");
            TakeDamge(1);
        }
        if(collision.gameObject.tag =="healspot")
        {
            FindObjectOfType<AudioManager>().Play("healSound");
            new WaitForSeconds(60f);
            hearts[life].gameObject.SetActive(true);
            life += 1;
        }
    }

    
    public void TakeDamge(int d)    //d = dmg
    {
            
        
            life -= d;
        // Destroy(hearts[life].gameObject);
        hearts[life].gameObject.SetActive(false);

            if (life < 1)
            {
                
                audio1.SetActive(false);
                audio2.SetActive(true);
                FindObjectOfType<AudioManager>().Play("characterDeathSound");
                DeathScreen.SetActive(true);
                FindObjectOfType<AudioManager>().Play("GameOverSound");
                
               

            }
        
    
    
    }




}
