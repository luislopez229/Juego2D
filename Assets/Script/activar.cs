using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar : MonoBehaviour
{
    bool unavez = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player") && unavez){
        gameObject.transform.parent.transform.GetChild(0).gameObject.SetActive(true);
        unavez = false;
        }
    
}
}
