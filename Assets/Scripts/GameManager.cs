using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    public enum GameState { Title, Playing, Paused, GameOver }
    public GameState State { get; private set; } = GameState.Title;

    [Header("Lives")]
    public int startingLives = 3;
    public int lives;

    [Header("Scene Names")]
    public string titleSceneName = "Title";
    public string gameSceneName = "Level1";

    [Header("UI Panels (in-scene)")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    private bool paused;

    private void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (State == GameState.Playing && Input.GetKeyDown(KeyCode.P))
            TogglePause();

        if (State == GameState.GameOver && Input.GetKeyDown(KeyCode.Escape))
            LoadTitle();
    }

    private void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        
        if (pausePanel == null)
        {
            var p = GameObject.Find("PausePanel");
            if (p) pausePanel = p;
        }
        if (gameOverPanel == null)
        {
            var g = GameObject.Find("GameOverPanel");
            if (g) gameOverPanel = g;
        }

        if (s.name == titleSceneName)
        {
            SetState(GameState.Title);
            SetPaused(false);
        }
        else
        {
            // Any non-title scene is considered gameplay here.
            if (State != GameState.Paused) SetState(GameState.Playing);
        }

        RefreshUI();
    }

    public void StartGame()
    {
        lives = startingLives;
        LoadGame();
    }

    public void LoadTitle()
    {
        SetPaused(false);
        pausePanel = null;
        gameOverPanel = null;
        SceneManager.LoadScene(titleSceneName);
    }

    public void LoadGame()
    {
        SetPaused(false);
        pausePanel = null;
        gameOverPanel = null;
        SceneManager.LoadScene(gameSceneName);
        SetState(GameState.Playing);
    }

    public void TogglePause()
    {
        if (State == GameState.GameOver || State == GameState.Title) return;
        SetPaused(!paused);
        SetState(paused ? GameState.Paused : GameState.Playing);
        RefreshUI();
    }

    public void PlayerDied()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
            return;
        }

        // Simple respawn: reload level scene
        // (fastest way, zero thinking)
        SetPaused(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SetState(GameState.Playing);
    }

    public void GameOver()
    {
        SetPaused(false);
        SetState(GameState.GameOver);
        RefreshUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetState(GameState s) => State = s;

    private void SetPaused(bool v)
    {
        paused = v;
        Time.timeScale = paused ? 0f : 1f;
    }

    private void RefreshUI()
    {
        if (pausePanel) pausePanel.SetActive(State == GameState.Paused);
        if (gameOverPanel) gameOverPanel.SetActive(State == GameState.GameOver);
    }
}
