using UnityEngine;
using UnityEngine.SceneManagement;
using Score;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; private set; }

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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetGame();
        TargetSpawner spawner = FindObjectOfType<TargetSpawner>();
        if (spawner != null)
        {
            spawner.InitializeSpawning();
            Debug.Log("Spawner reinitialized after scene reload.");
        }
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(Score);
        }
    }

    public void ResetGame()
    {
        Score = 0;
    }

    public void AddScore(int points)
    {
        Score += DLLScore.AddScoreBonus(points);

        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(Score);
            UIManager.Instance.CheckGameEnd(Score);
        }
    }
}