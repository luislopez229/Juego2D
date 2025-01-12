using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculoMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    bool volviendo;
    public Vector2 posFinal;
    Vector2 posInicial;

    public bool modo;
    float velocidad = 3f;
    void Start()
    {
        if(modo)
        velocidad = 6f;
        posInicial = transform.position;
        volviendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 destination = volviendo ? posFinal : posInicial;

        transform.position = Vector2.MoveTowards(transform.position, destination, velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, destination) < 0.01f)
        {
            if(modo)
                transform.position = posInicial;
            else
            volviendo = !volviendo;
        }

    }
}
