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
                SetData(data);
            }
        }
        catch
        {
            var warnning = "Data cannot be uploaded, the save file is corrupted!!!";
            _menuUI.HandleExeption(warnning);
        }
    }

    private void SetData(SaveData data)
    {
        for (int i = 0; i < data.Names.Length; i++)
        {
            GameData.SetBestPlayer(i, data.Names[i]);
            GameData.SetBestScore(i, data.Scores[i]);
        }
    }
}
