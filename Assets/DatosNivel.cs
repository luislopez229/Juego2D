using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DatosNivel : MonoBehaviour
{
    public static DatosNivel instance;
    private Vector2 lastCheckpointPosition;
    public Text timerText; // Referencia al texto del UI para mostrar el tiempo
    private float elapsedTime; // Tiempo transcurrido
    private bool isRunning; // Estado del contador

    private void Awake()
    {
        PlayerPrefs.SetFloat("tiempo1", 0f);
        PlayerPrefs.SetFloat("tiempo2", 0f);
        PlayerPrefs.SetFloat("tiempo3", 0f);
        elapsedTime = 0f;
        isRunning = true; // Comienza el contador
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el GameManager en todas las escenas.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update(){
        
       if (isRunning)
        {
            // Incrementa el tiempo acumulado
            elapsedTime += Time.deltaTime;

            // Actualiza el texto en pantalla
            UpdateTimerDisplay();
        }
    }
public void SetCheckpoint(Vector2 checkpointPosition)
{
    lastCheckpointPosition = checkpointPosition;
    PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
    PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
}

public Vector2 GetLastCheckpoint()
{
    float x = PlayerPrefs.GetFloat("CheckpointX", 0);
    float y = PlayerPrefs.GetFloat("CheckpointY", 0);
    return new Vector2(x, y);
}

    void LevelComplete()
    {
        PauseTimer(); // Pausa el temporizador
        float finalTime = GetElapsedTime();

        Debug.Log("¡Nivel completado! Tiempo final: " + finalTime + " segundos");

        // Opcional: Cargar siguiente nivel
        SceneManager.LoadScene("castillo");
    }


        // Formatear y actualizar el texto del temporizador
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Minutos
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Segundos
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Pausar el temporizador
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Reanudar el temporizador
    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Reiniciar el temporizador
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    // Obtener el tiempo actual
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}