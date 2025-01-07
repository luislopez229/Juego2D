using UnityEngine;

public class Grua : MonoBehaviour
{
    public GameObject objectToMove; // El objeto que queremos mover
    public float moveSpeed = 2f; // Velocidad de movimiento
    public Vector3 moveDirection; // Dirección en la que queremos mover el objeto

    private bool isPlayerInside = false; // Bandera para verificar si el jugador está en el Trigger

    void Update()
    {
        // Si el jugador está dentro del Trigger, mueve el objeto en la dirección especificada
        if (isPlayerInside)
        {
            objectToMove.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto que entra al Trigger es el jugador
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Cuando el jugador sale del Trigger, detenemos el movimiento
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
