using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject endPanel;
    public GameObject gameScoreText;
    public GameObject gameTimeText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI finalTimeText;
    public Button restartButton;

    private float timer;
    private bool gameOver;
    private int totalClicks;
    private int successfulHits;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        
        Time.timeScale = 1f;
        timer = 0f;
        gameOver = false;
        totalClicks = 0;
        successfulHits = 0;
        endPanel.SetActive(false);
        gameScoreText.SetActive(true);
        gameTimeText.SetActive(true);
        timerText.text = "Time:";
        scoreText.text = "Score: 0";
    }

    private void Update()
    {
        if (gameOver) return;

        timer += Time.deltaTime;
        timerText.text = $"Time: {timer:F1}";

        if (timer >= 20f)
        {
            gameOver = true;
            ShowEndPanel();
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void RegisterClick(bool hit)
    {
        totalClicks++;
        if (hit)
            successfulHits++;
    }

    public void CheckGameEnd(int score)
    {
        if (score >= 100 && !gameOver)
        {
            gameOver = true;
            ShowEndPanel();
        }
    }

    void ShowEndPanel()
    {
        endPanel.SetActive(true);
        gameScoreText.SetActive(false);
        gameTimeText.SetActive(false);

        float accuracy = totalClicks > 0 ? ((float)successfulHits / totalClicks) * 100f : 0f;

        finalScoreText.text = $"Final Score: {GameManager.Instance.Score}";
        accuracyText.text = $"Accuracy: {accuracy:F1}%";
        finalTimeText.text = $"Time: {timer:F1} seconds";

        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
