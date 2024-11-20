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

    private void Start()
    {
        _bestScoreText.text = "Best Score: " + GameData.BestPlayer + ": " + GameData.BestScore;

        _startButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(ExitGame);

        _nameField.onEndEdit.AddListener(SetPlayerName);
    }

    private void StartGame() => SceneLoader.LoadScene(GlobalConstants.MainSceneName);

    public void SetPlayerName(string name) => GameData.SetName(name);
   
    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}