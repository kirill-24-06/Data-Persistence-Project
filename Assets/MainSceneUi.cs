using UnityEngine;
using UnityEngine.UI;
using Utils.SceneLoading;

public class MainSceneUi : MonoBehaviour
{
    [SerializeField] private Button _exitGameButton;

    private void Start() => _exitGameButton.onClick.AddListener(GoToMenu);

    private void GoToMenu() => SceneLoader.LoadScene(GlobalConstants.MainMenuSceneName);  
}