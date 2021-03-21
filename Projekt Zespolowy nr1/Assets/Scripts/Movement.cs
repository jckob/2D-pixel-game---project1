using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public enum PlayerState
{
    walk,
    Attack,
    interact
}
public class Movement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;     // deklarujemy szybkosc z jaka nasza postac ma sie poruszac
    private Rigidbody2D myRb; // deklarujemy tylko w tym skrypcie Rigidbody 2D ktory zapewnia nam fizyke naszej postaci
    private Vector3 change; // deklarujemy Vector3 ktory odpowiada za kierunek poruszania sie i nazywamy go "change" 
    private Animator animator;
    
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();        // Pobieramy z Animatora wszystkie jego komponenty.
        myRb = GetComponent<Rigidbody2D>();         // Pobieramy z Rigidbody 2D wszystkie jej komponenty
    }

   
    void Update()
    {
        change = Vector3.zero;      // ustalamy ze naszym poczatkowym wektorem bedzie wektor 0 czyli nie bedzie okreslone w ktora strone sie poruszamy
        change.x = Input.GetAxisRaw("Horizontal");  // deklarujemy ze change.x bedzie pobierany z osi poziomej
        change.y = Input.GetAxisRaw("Vertical"); // deklarujemy ze change.y bedzie pobieranie z osi pionowej
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.Attack)
        {
            StartCoroutine(AttackCo());
        }
        else if(change != Vector3.zero) // jezeli nasza zmiana jest wieksza od wektoru poczatkowego wtedy pobierz z funkcji "MoveCharacter" wszystkie komponenty ()
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);   
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("moving", true);
        }
        else 
        {
            animator.SetBool("moving", false);
                
        }
    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        FindObjectOfType<AudioManager>().Play("attackSwordSound");
        currentState = PlayerState.Attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
    void MoveCharacter()   // w tym momencie deklarujemy nowa formule, ktora odnosi sie do komponentow z funkcji "MoveCharacter" (nowe formuly powinny byc zawsze poza Updatem
    {
        myRb.MovePosition(transform.position + change * speed * Time.deltaTime); // W funkcji RigidBody 2D zmieniamy komponent odpowiedni za ruch (MovePosition) i mowimy, ze ma zmienic pozycje
                                                                                 // i dodac do niej zmiane pomnozana przez szybkosc oraz czas od ukonczenia poprzedniej klatki (Time.deltaTime).
    }
}
 