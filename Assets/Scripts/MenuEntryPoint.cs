using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private MainMenuUI _menuUI;

    private void Awake()
    {
        try
        {
            var data = SaveLoad.Load();

            if (data != null)
            {
                GameData.SetBestPlayer(data.Name);
                GameData.SetBestScore(data.Score);
            }
        }
        catch
        {
            var warnning = "Data cannot be uploaded, the save file is corrupted!!!";
            _menuUI.HandleExeption(warnning);
        }
    }
}
