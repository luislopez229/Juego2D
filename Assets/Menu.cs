using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject opciones;
    public GameObject creditos;
    public GameObject instr;
    bool opb = false;
    bool crb = false;
    bool insb = false;
    public void botonOpciones()
    {
        opb = !opb;
        opciones.gameObject.SetActive(opb);
    }

    public void botonCreditos()
    {
        crb = !crb;
        creditos.gameObject.SetActive(crb);
    }

    public void botonInstrucciones()
    {
        insb = !insb;
        instr.gameObject.SetActive(insb);
    }
}
