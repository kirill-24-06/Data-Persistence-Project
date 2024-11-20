using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.SceneLoading;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _nameBoard;
    [SerializeField] private TextMeshProUGUI[] _scoreBoard;

    [SerializeField] private Button _exitButton;

    private void Start()
    {
        ShowLeaders();
        _exitButton.onClick.AddListener(GoToMenu);
    }

    private void ShowLeaders()
    {
        for (int i = 0; i < GameData.BestPlayers.Length; i++)
        {
            if (GameData.BestPlayers[i] != null)
            {
                _nameBoard[i].text = GameData.BestPlayers[i];
                _scoreBoard[i].text = GameData.BestScores[i].ToString();
            }

            else
            {
                _nameBoard[i].text = "Empty";
                _scoreBoard[i].text = "___________________";
            }
        }
    }

    private void GoToMenu() => SceneLoader.LoadScene(GlobalConstants.MainMenuSceneName);
}