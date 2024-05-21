
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject getReady;
    private int score;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 0f;
        getReady.SetActive(true);
        playButton.SetActive(true);
        player.transform.position = new Vector3(0, 0, 0);
        player.enabled = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Back to Menu");
            Application.Quit();
        }
    }

    public void Play() {
        //codigo debug para verificar si el boton play esta funcionando
        Debug.Log("Play");
        //iniciamos el marcador a cero
        score = 0;
        scoreText.text = score.ToString();
        //desactivamos los paneles de getReady y playButton
        getReady.SetActive(false);
        gameOver.SetActive(false);
        playButton.SetActive(false);
        player.transform.position = new Vector3(0, 0, 0);
        //mostramos al jugador
        player.enabled = true;
        //limpiamos los tubos que pudieran existir de una partida anterior
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes) {
            Destroy(pipe.gameObject);
        }
        //iniciamos juego a tiempo real
        Time.timeScale = 1f;
    }

    public void GameOver() {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }

}
