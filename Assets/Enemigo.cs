using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{

    public Transform player;  // Referencia al jugador
    public float speed = 2f;  // Velocidad del enemigo
    public Animator anim;
    private Rigidbody2D rb;
    public float rangoCerca = 3f;
    private bool ataca = false;
    public GameObject[] muertes;
    public bool muriendo = false;
    Color tmp;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(player.position, transform.position) <= rangoCerca)
            ataca = true;

        if (ataca)
        {
            // Calcular dirección hacia el jugador
            Vector2 direction = player.position - transform.position;

        // Redondear dirección a las 8 direcciones posibles
        direction = Get8DirectionVector(direction);
        anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);
        // Mover al enemigo
        transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    Vector2 Get8DirectionVector(Vector2 direction)
    {
        // Normalizar el vector de dirección
        direction.Normalize();

        // Redondear las componentes X e Y a -1, 0 o 1
        float roundedX = Mathf.Round(direction.x);
        float roundedY = Mathf.Round(direction.y);

        // Crear el vector redondeado
        Vector2 roundedDirection = new Vector2(roundedX, roundedY);

        // Si el vector es nulo (0, 0), mantener la dirección original
        if (roundedDirection == Vector2.zero)
        {
            roundedDirection = direction;
        }

        return roundedDirection;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Muere() {
        Instantiate(muertes[Random.Range(0, muertes.Length)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    /*[SerializeField] private float vel = 1f;
    Transform coorJugador;



    // Update is called once per frame

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
    */
    /*
     using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Asigna el objeto jugador desde el inspector
    public float speed = 3f;  // Velocidad del enemigo

    void Update()
    {

    }

}
*/
}
