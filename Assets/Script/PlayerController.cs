using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 smoothMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private Animator anim;

    public Tilemap tm;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = movementInput * speed;

        anim.SetFloat("x", movementInput.x);
        anim.SetFloat("y", movementInput.y);
        anim.SetFloat("speed", movementInput.sqrMagnitude);
    }

    void Update()
    {
        //Debug.Log("VEL: "+rb.velocity);
    }

    void OnEnable()
    {
        Vector3Int tilePosition = tm.WorldToCell(transform.position);
        bool tile = tm.HasTile(tilePosition);

            if (tile == false)
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    }
}
