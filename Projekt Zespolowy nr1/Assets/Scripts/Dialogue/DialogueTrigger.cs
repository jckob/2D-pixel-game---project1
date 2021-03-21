using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Response response;
    public bool Hit;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
       // FindObjectOfType<DialogueManager>().StartResponses(response);
    }

    private void OnTriggerEnter2D(Collider2D other)
    
        
    
    {

        if ((other.gameObject.name == "Player") && (Hit == false))
        {
            Hit = true;
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)   
    
    {
        if ((collision.gameObject.name == "Player") && (Hit == true))
        {
            Hit = false;
        }
    }

}
