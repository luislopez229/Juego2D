using UnityEngine;
using UnityEngine.Tilemaps;

public class fondo : MonoBehaviour
{/*
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<TilemapRenderer>().bounds.size.x;
    }

void Update()
{
    float temp = (cam.transform.position.x * (1 - parallaxEffect));
    float dist = (cam.transform.position.x * parallaxEffect);

    transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

    if (temp > startpos + length) startpos += length;
    else if (temp < startpos - length) startpos -= length;
}*/
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

    /*using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed = 2f;  // Velocidad de movimiento de la nube
    private Camera mainCamera;

    void Start()
    {
        // Obtener la c�mara principal
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Mover la nube diagonalmente
        transform.position += new Vector3(1, 1, 0).normalized * speed * Time.deltaTime;

        // Verificar si la nube est� fuera de la vista de la c�mara
        if (!IsInView())
        {
            TeleportToOppositeCorner();
        }
    }

    bool IsInView()
    {
        // Obtener las coordenadas de la posici�n de la nube en la c�mara
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Verificar si est� dentro de los l�mites de la c�mara (0-1 en X e Y)
        return viewportPosition.x > 0 && viewportPosition.x < 1 &&
               viewportPosition.y > 0 && viewportPosition.y < 1;
    }

    void TeleportToOppositeCorner()
    {
        // Obtener las coordenadas de la posici�n de la nube en la c�mara
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Teletransportar a la esquina opuesta
        if (viewportPosition.x > 1) viewportPosition.x = 0;  // Sali� por la derecha
        else if (viewportPosition.x < 0) viewportPosition.x = 1;  // Sali� por la izquierda

        if (viewportPosition.y > 1) viewportPosition.y = 0;  // Sali� por arriba
        else if (viewportPosition.y < 0) viewportPosition.y = 1;  // Sali� por abajo

        // Convertir de nuevo a coordenadas del mundo y aplicar la nueva posici�n
        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);
    }
}
*/
}