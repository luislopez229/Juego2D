using UnityEngine;

public class Grua : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveSpeed = 2f;
    public Vector3 moveDirection;

    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside)
        {
            objectToMove.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
