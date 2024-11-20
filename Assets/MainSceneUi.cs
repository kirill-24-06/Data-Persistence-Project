using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.SceneLoading;

public class MainSceneUi : MonoBehaviour
{
    [SerializeField] private Button _exitGameButton;

    public Action MenuExit;

    private void Start() => _exitGameButton.onClick.AddListener(GoToMenu);

    private void GoToMenu()
    {
        MenuExit?.Invoke();
        SceneLoader.LoadScene(GlobalConstants.MainMenuSceneName);
    }
}