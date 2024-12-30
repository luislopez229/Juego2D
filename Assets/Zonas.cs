using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zonas : MonoBehaviour
{
    Color tmp;
    bool destruido;
    

        private void Start()
    {
        tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        destruido = false;
        Physics2D.IgnoreLayerCollision(23,23,true);
    }
    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player") && !destruido){

            gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }else if (collision.tag.Equals("Enemigo") && !destruido)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().color = tmp;
            destruido=true;
            collision.gameObject.GetComponent<Enemigo>().Muere();
        }
    }
}
