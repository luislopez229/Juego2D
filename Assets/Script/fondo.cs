using UnityEngine;
using UnityEngine.Tilemaps;

public class fondo : MonoBehaviour
{
    private Vector2 startpos;
    public GameObject cam;
    public float parallaxEffect;
    bool prueba;

    private Vector3 target;

    void Start()
    {
        startpos = transform.position;
        prueba = false;

    }

    void Update()
    {
        if(!prueba){
        target = new Vector3(cam.transform.position.x + 30,cam.transform.position.y + 30,0);
        prueba = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, 0.001f);
    if (transform.position == target){
        transform.position = new Vector3(cam.transform.position.x - 20, cam.transform.position.y - 20, 0);
        prueba = false;
    }
    }
}