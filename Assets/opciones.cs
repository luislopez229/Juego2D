using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class opciones : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider volumeSlider;
    public Slider fpsSlider;
    public TextMeshProUGUI fpsHandleText;
    private bool isMenuActive = false;

    void Start()
    {
        // Asegúrate de que el menú esté desactivado al inicio
        optionsPanel.SetActive(false);

        // Cargar configuraciones guardadas
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f); // Volumen predeterminado: 1 (máximo)
        int savedFPS = PlayerPrefs.GetInt("FPS", 60); // FPS predeterminado: 60


        // Asignar valores iniciales a los sliders
        volumeSlider.value = savedVolume;
        fpsSlider.value = savedFPS;


        // Aplicar configuraciones guardadas
        AudioListener.volume = savedVolume;
        Application.targetFrameRate = savedFPS;

        // Asigna las funciones de cambio
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        fpsSlider.onValueChanged.AddListener(value =>
        {
            ChangeFPS(value);
            UpdateFPSHandleText(value);
        });
    }

    void Update()
    {
        // Abrir o cerrar el menú con Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            optionsPanel.SetActive(isMenuActive);
            Time.timeScale = isMenuActive ? 0 : 1; // Pausar el juego cuando el menú esté abierto
        }

    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume); // Guardar el volumen
    }

    public void ChangeFPS(float fps)
    {
        Application.targetFrameRate = (int)fps;
        PlayerPrefs.SetInt("FPS", (int)fps); // Guardar los FPS
    }

        void UpdateFPSHandleText(float value)
    {
        fpsHandleText.text = ((int)value).ToString(); // Muestra un número entero
    }

    public void CloseMenu()
    {
        isMenuActive = false;
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
