using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public bool isActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DatosNivel.instance.SetCheckpoint(transform.position);
            isActive = true;
        }
    }
}

