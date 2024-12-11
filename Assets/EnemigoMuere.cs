using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMuere : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float dirX;
    float dirY;
    float torque;
    void Start()
    {
        dirX = Random.Range(-5,5);
        dirY = Random.Range(-5, 8);
        torque = Random.Range(5, 15);
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);

        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
