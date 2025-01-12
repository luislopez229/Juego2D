using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public bool impulsandose;
    private transition t;

    AudioSource audio;
    public bool solounavez;
    
    void Start()
    {
        audio = GameObject.Find("Player").GetComponent<AudioSource>();
        t = GameObject.Find("LevelManager").GetComponent<transition>();
        impulsandose = false;
        solounavez = false;

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

        if(impulsandose && !solounavez){
            audio.Play();
            solounavez=true;
        }

    }

        IEnumerator respawnDelay()
    {
        yield return new WaitForSeconds(0.6f);
        transform.position = DatosNivel.instance.GetLastCheckpoint();
        t.animator.SetTrigger("trigger");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }


}
