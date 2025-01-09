using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarcamara : MonoBehaviour
{
    public Camera cam;
    private GameObject main;

    void Start(){
    main = GameObject.FindGameObjectWithTag("MainCamera");
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player")){
        main.SetActive(false);
        cam.gameObject.SetActive(true);
        }
    
}

   private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player")){
        main.SetActive(true);
        cam.gameObject.SetActive(false);
        }
    
}
}
