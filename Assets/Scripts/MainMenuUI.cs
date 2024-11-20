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
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TMP_InputField _nameField;

    private string _bestScore;

    private bool _isExeption = false;

    private void Start()
    {
        if (!_isExeption)
            _bestScore = "Best Score: " + GameData.BestPlayer + ": " + GameData.BestScore;

        _bestScoreText.text = _bestScore;

        _startButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(ExitGame);

        _nameField.onEndEdit.AddListener(SetPlayerName);
    }

    private void StartGame() => SceneLoader.LoadScene(GlobalConstants.MainSceneName);

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