using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class arranque : MonoBehaviour
{
    public GameObject grua;
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && (other.gameObject.transform.childCount > 0) && SceneManager.GetActiveScene().buildIndex != 3)
            {
                other.gameObject.transform.SetParent(grua.transform,true);
                grua.SetActive(true);
            }else{
                grua.SetActive(true);
            }
        }
}
