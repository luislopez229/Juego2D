using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DatosNivel : MonoBehaviour
{
    public static DatosNivel instance;
    private Vector2 lastCheckpointPosition;
    public Text timerText; 
    private float elapsedTime; 
    private bool isRunning; 
    public AudioSource audioSource;

    private void Awake()
    {
        elapsedTime = 0f;
        isRunning = true;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update(){
        
       if (isRunning)
        {
            elapsedTime += Time.deltaTime;

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

    public void LevelComplete()
    {
        PauseTimer();
        float finalTime = GetElapsedTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public Text GetTimerText()
    {
        return timerText;
    }

    public void Reset()
    {
        GetComponent<AudioSource>().Stop();
        PlayerPrefs.SetFloat("CheckpointX", 0);
        PlayerPrefs.SetFloat("CheckpointY", 0);
        Destroy(gameObject);
    }
}