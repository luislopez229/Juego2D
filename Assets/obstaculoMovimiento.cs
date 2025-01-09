using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculoMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    bool volviendo;
    public Vector2 posFinal;
    Vector2 posInicial;
    void Start()
    {
        posInicial = transform.position;
        volviendo = false;
    }

    // Update is called once per frame
    void Update()
    {
        while(!volviendo){
        transform.position = Vector2.MoveTowards(transform.position,posFinal,2* Time.deltaTime);
        if(transform.position.x == posFinal.x)
            volviendo=true;
        }
        while(volviendo){
        transform.position = Vector2.MoveTowards(transform.position,posInicial,2* Time.deltaTime);
        if(transform.position.x == posInicial.x)
        volviendo=false;
}
        
            

    }
}
