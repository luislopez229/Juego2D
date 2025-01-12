using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class opciones : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider volumeSlider;

    public Slider sonidoSlider;
    public Slider fpsSlider;
    public TextMeshProUGUI fpsHandleText;
    private bool isMenuActive = false;

    public Toggle nubes;
    public Toggle debug;
    public GameObject targetObject;
    [SerializeField] private GameObject jug;

void Awake(){
        jug = GameObject.Find("Player");
}
    void Start()
    {
        optionsPanel.SetActive(false);

        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        float savedSonido = PlayerPrefs.GetFloat("Sonido", 0.5f);
        int savedFPS = PlayerPrefs.GetInt("FPS", 60);


        volumeSlider.value = savedVolume;
        sonidoSlider.value = savedSonido;
        fpsSlider.value = savedFPS;



        AudioListener.volume = savedVolume;
        jug.GetComponent<AudioSource>().volume = savedSonido;
        Application.targetFrameRate = savedFPS;


        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        sonidoSlider.onValueChanged.AddListener(ChangeSonido);
        fpsSlider.onValueChanged.AddListener(value =>
        {
            ChangeFPS(value);
            UpdateFPSHandleText(value);
        });

        nubes.onValueChanged.AddListener(value => targetObject.SetActive(value));

        debug.onValueChanged.AddListener(value => {
        
        if(!value){
            jug.GetComponent<BoxCollider2D>().excludeLayers = 0;
            jug.transform.GetChild(1).GetComponent<BoxCollider2D>().excludeLayers = 0;
            }
        else{
        jug.GetComponent<BoxCollider2D>().excludeLayers = 1 << 21;
        jug.transform.GetChild(1).GetComponent<BoxCollider2D>().excludeLayers = 1 << 21;
        }
         
         });
    }

    void Update()
    {
        if(jug == null){
            jug = GameObject.Find("Player");
            targetObject = GameObject.Find("Grid/Deco2");

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            optionsPanel.SetActive(isMenuActive);
            Time.timeScale = isMenuActive ? 0 : 1;
        }

    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void ChangeSonido(float volume)
    {
        jug.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("Sonido", volume);
    }

    public void ChangeFPS(float fps)
    {
        Application.targetFrameRate = (int)fps;
        PlayerPrefs.SetInt("FPS", (int)fps);
    }

        void UpdateFPSHandleText(float value)
    {
        fpsHandleText.text = ((int)value).ToString();
    }

    public void CloseMenu()
    {
        isMenuActive = false;
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void botonRespawn(){
        jug.GetComponent<Control>().Respawn();
        CloseMenu();
    }

    public void botonMenu(){
        DatosNivel.instance.Reset();
        SceneManager.LoadScene(0);
        CloseMenu();
    }

    public void botonSinCP(){
        if(SceneManager.GetActiveScene().buildIndex == 1){
            DatosNivel.instance.SetCheckpoint(new Vector2(0,0));
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3){
            DatosNivel.instance.SetCheckpoint(new Vector2(-77.38f,12.01f));
        }
        Debug.Log(DatosNivel.instance.GetLastCheckpoint());
        jug.GetComponent<Control>().Respawn();
        CloseMenu();
    }
}
