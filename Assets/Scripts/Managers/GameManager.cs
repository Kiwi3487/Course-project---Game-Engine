using UnityEngine;
using UnityEngine.SceneManagement;
using Score;
using Patterns.State;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }

    private GameState currentState;
    private bool gameEnded;

    public bool IsEndingState => gameEnded;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        SwitchState(new Playing());
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameEnded = false;
        SwitchState(new Playing());

        ResetGame();

        TargetSpawner spawner = FindObjectOfType<TargetSpawner>();
        if (spawner != null)
            spawner.InitializeSpawning();

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateScore(Score);
    }

    public void SwitchState(GameState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void ResetGame()
    {
        Score = 0;
    }

    public void AddScore(int points)
    {
        if (gameEnded) return;

        Score += DLLScore.AddScoreBonus(points);

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(Score);
            UIManager.Instance.CheckGameEnd(Score);
        }
    }

    public void TriggerEndState()
    {
        gameEnded = true;
        SwitchState(new Ending());
    }
}