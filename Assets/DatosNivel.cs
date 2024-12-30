using UnityEngine;

public class DatosNivel : MonoBehaviour
{
    public static DatosNivel instance;
    private Vector2 lastCheckpointPosition;

    private void Awake()
    {
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
}