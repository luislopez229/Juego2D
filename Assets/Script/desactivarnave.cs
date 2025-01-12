using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivarnave : MonoBehaviour
{
public GameObject nave;
    void OnDisable(){
        nave.SetActive(false);
    }
}

