using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulsos : MonoBehaviour
{
    private GameObject IM;
    private bool impulsandose;

    private Animator anim;
    private void Start()
    {
        IM = GameObject.Find("IM");
        impulsandose = false;
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.name == "Player" || other.gameObject.name == "Enemigo"))
        {

            switch (this.gameObject.name)
            {
                case "ImpulsoDerecha":
                    if (other.GetComponent<Control>().impulsandose == false)
                    {
                        other.GetComponent<Control>().impulsandose = true;
                        
                        if (other.gameObject.name == "Player")
                        {
                            anim.SetBool("girando", true);
                            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            other.GetComponent<PlayerController>().enabled = false;
                        }
                        else
                        { other.GetComponent<Enemigo>().enabled = false; }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8, ForceMode2D.Impulse);
                        other.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    break;
                case "ImpulsoIzquierda":
                    if (other.GetComponent<Control>().impulsandose == false)
                    {
                        other.GetComponent<Control>().impulsandose = true;
                        
                        if (other.gameObject.name == "Player")
                        {
                            anim.SetBool("girando", true);
                            other.GetComponent<PlayerController>().enabled = false;
                        }
                        else
                        { other.GetComponent<Enemigo>().enabled = false; }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 8, ForceMode2D.Impulse);
                        other.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    break;
                case "ImpulsoAbajo":
                    if (other.GetComponent<Control>().impulsandose == false)
                    {
                        other.GetComponent<Control>().impulsandose = true;
                        
                        if (other.gameObject.name == "Player")
                        {
                            anim.SetBool("girando", true);
                            other.GetComponent<PlayerController>().enabled = false;
                        }
                        else
                        { other.GetComponent<Enemigo>().enabled = false; }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 8, ForceMode2D.Impulse);
                        other.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    break;
                case "ImpulsoArriba":
                    if (other.GetComponent<Control>().impulsandose == false)
                    {
                        other.GetComponent<Control>().impulsandose = true;
                        
                        if (other.gameObject.name == "Player")
                        {
                            anim.SetBool("girando", true);
                            other.GetComponent<PlayerController>().enabled = false;
                        }
                        else
                        { other.GetComponent<Enemigo>().enabled = false; }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                        other.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    break;

                case "BloqueoJugador":

                    if (other.gameObject.name == "Enemigo")
                    {
                        Debug.Log("Hola");
                        break;
                    }
                        break;
                    
                default:
                    other.GetComponent<Control>().impulsandose = false;
                    
                    if (other.gameObject.name == "Player")
                    {
                        anim.SetBool("girando", false);
                        other.GetComponent<PlayerController>().enabled = true;
                    }
                    else
                    { other.GetComponent<Enemigo>().enabled = true; }
                    other.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
            }
        }
    }
}
