using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text option1Text;
    public Text option2Text;

    public Queue<string> sentences;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)

    {
        animator.SetBool("IsOpen", true);

        UnityEngine.Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

   // public void StartResponses(Response responses)
   // {
   //     option1Text.text = responses.option1;
   //     option2Text.text = responses.option2;
   // }
    public void DisplayNextSentence()
    {

        if (sentences.Count == 1)
        {
            //
        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        UnityEngine.Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        UnityEngine.Debug.Log("End of conversation");
    }
}

