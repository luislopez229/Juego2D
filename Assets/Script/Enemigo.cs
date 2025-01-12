using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{

    public Transform player;
    public float speed = 2f;
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
            Vector2 direction = player.position - transform.position;

        direction = Get8DirectionVector(direction);
        anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);
        transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    Vector2 Get8DirectionVector(Vector2 direction)
    {
        direction.Normalize();

        float roundedX = Mathf.Round(direction.x);
        float roundedY = Mathf.Round(direction.y);
        Vector2 roundedDirection = new Vector2(roundedX, roundedY);

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
}
