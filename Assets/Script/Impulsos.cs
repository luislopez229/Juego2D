using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Impulsos : MonoBehaviour
{
    private GameObject IM;
    private bool impulsandose;

    private Animator anim;
    private GameObject obsTm;
    private void Start()
    {
        IM = GameObject.Find("IM");
        impulsandose = false;
        anim = GameObject.Find("Player").GetComponent<Animator>();
        obsTm = GameObject.Find("Grid/Obstaculo");
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
                            Physics2D.IgnoreLayerCollision(21, 22, true);
                        }
                        else
                        {
                            other.GetComponent<Animator>().SetBool("girando", true);
                            other.GetComponent<Enemigo>().enabled = false;
                            other.transform.GetChild(0).GetComponent<BoxCollider2D>().excludeLayers = 1 << 21;
                        }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8, ForceMode2D.Impulse);
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
                            Physics2D.IgnoreLayerCollision(21, 22, true);
                        }
                        else
                        {
                            other.GetComponent<Animator>().SetBool("girando", true);
                            other.GetComponent<Enemigo>().enabled = false;
                            other.transform.GetChild(0).GetComponent<BoxCollider2D>().excludeLayers = 1 << 21;
                        }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 8, ForceMode2D.Impulse);
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
                            Physics2D.IgnoreLayerCollision(21, 22, true);
                        }
                        else
                        {
                            other.GetComponent<Animator>().SetBool("girando", true);
                            other.GetComponent<Enemigo>().enabled = false;
                            other.transform.GetChild(0).GetComponent<BoxCollider2D>().excludeLayers = 1 << 21;
                        }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 8, ForceMode2D.Impulse);
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
                            Physics2D.IgnoreLayerCollision(21, 22, true);
                        }
                        else
                        {
                            other.GetComponent<Animator>().SetBool("girando", true);
                            other.GetComponent<Enemigo>().enabled = false;
                            other.transform.GetChild(0).GetComponent<BoxCollider2D>().excludeLayers = 1 << 21;
                        }
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
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

                    switch (this.gameObject.name)
                    {
                        case "ReboteDer":
                            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            other.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8, ForceMode2D.Impulse);
                            break;
                        case "ReboteIz":
                            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            other.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 8, ForceMode2D.Impulse);
                            break;
                        case "ReboteAr":
                            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                            break;
                        case "ReboteAb":
                            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            other.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 8, ForceMode2D.Impulse);
                            break;
                        default:
                            other.GetComponent<Control>().impulsandose = false;
                            other.GetComponent<Control>().solounavez = false;
                            if (other.gameObject.name == "Player")
                            {
                                anim.SetBool("girando", false);
                                other.GetComponent<PlayerController>().enabled = true;
                                Physics2D.IgnoreLayerCollision(21, 22, false);
                            }
                            else
                            {
                                other.GetComponent<Animator>().SetBool("girando", false);
                                other.GetComponent<Enemigo>().enabled = true;
                                other.transform.GetChild(0).GetComponent<BoxCollider2D>().excludeLayers = 0;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
