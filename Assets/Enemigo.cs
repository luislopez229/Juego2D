using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vel = 1f;
    Transform coorJugador;
    private Rigidbody2D rb;

    private float rangoCerca = 3f;
    private bool ataca = false;
    // Update is called once per frame
    private void Start()
    {
        coorJugador = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(Vector2.Distance(coorJugador.position, transform.position)  <= rangoCerca)
        ataca=true;

        if(ataca){
        Vector3 dir = (coorJugador.position - transform.position).normalized;
        rb.velocity = new Vector2(dir.x, dir.y)  * vel;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player")
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
