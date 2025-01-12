using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class cargarSiguienteNivel : MonoBehaviour
{

    void Start()
    {
        if((SceneManager.GetActiveScene().buildIndex) % 2 == 0){
            GameObject.Find("LevelManager/Canvas/tTotal").GetComponent<Text>().transform.localScale = new Vector3(0,0,0);
        }else{
             GameObject.Find("LevelManager/Canvas/tTotal").GetComponent<Text>().transform.localScale = new Vector3(1,1,1);
        }
        if(gameObject.CompareTag("Texto"))
        {
            GetComponent<Text>().text = GameObject.Find("LevelManager/Canvas/tTotal").GetComponent<Text>().text;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        DatosNivel.instance.LevelComplete();
        }
    }

    public void siguiente(){
        DatosNivel.instance.ResumeTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void volverMenu(){
        DatosNivel.instance.Reset();
        SceneManager.LoadScene(0);
    }
}
