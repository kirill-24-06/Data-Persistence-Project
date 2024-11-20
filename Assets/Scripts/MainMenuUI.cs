using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.SceneLoading;
# if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _leaderboardButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TMP_InputField _nameField;

    private string _bestScore;

    private bool _isExeption = false;

    private void Start()
    {
        if (!_isExeption)
            _bestScore = "Best Score: " + GameData.BestPlayers[0]
                + ": " + GameData.BestScores[0];

        _bestScoreText.text = _bestScore;

        _startButton.onClick.AddListener(StartGame);
        _leaderboardButton.onClick.AddListener(ShowLeaderboard);
        _exitButton.onClick.AddListener(ExitGame);

        _nameField.onEndEdit.AddListener(SetPlayerName);
    }

    private void StartGame() => SceneLoader.LoadScene(GlobalConstants.MainSceneName);

    private void ShowLeaderboard() => SceneLoader.LoadScene(GlobalConstants.LeaderboardSceneName);

    public void SetPlayerName(string name) => GameData.SetName(name);

    public void HandleExeption(string exeptionWarning)
    {
        _isExeption = true;
        _bestScoreText.color = Color.red;
        _bestScore = exeptionWarning;
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}