using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arranque : MonoBehaviour
{
    public GameObject grua;
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                grua.SetActive(true);
            }
        }
}
