using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public bool impulsandose;
    private transition t;
    void Start()
    {
        t = GameObject.Find("LevelManager").GetComponent<transition>();
        impulsandose = false;
    }

    public void Respawn()
    {   
        t.animator.SetTrigger("trigger");
        StartCoroutine(respawnDelay());
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R)){
            Respawn();
        }
    }

        IEnumerator respawnDelay()
    {
        yield return new WaitForSeconds(1f);
        transform.position = DatosNivel.instance.GetLastCheckpoint();
        t.ReloadLevel();
        
    }
}
