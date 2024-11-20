using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    private static BinaryFormatter _formatter = new BinaryFormatter();

    public static void Save()
    {
        var saveStream = new FileStream(GlobalConstants.BinarySavePath, FileMode.Create);

        var data = new SaveData()
        {
            Names = new string[]
            {
                GameData.BestPlayers[0],
                GameData.BestPlayers[1],
                GameData.BestPlayers[2],
                GameData.BestPlayers[3],
                GameData.BestPlayers[4],
            },

            Scores = new int[]
            {
                GameData.BestScores[0],
                GameData.BestScores[1],
                GameData.BestScores[2],
                GameData.BestScores[3],
                GameData.BestScores[4],
            }
        };

        _formatter.Serialize(saveStream, data);

        saveStream.Close();
    }

    public static SaveData Load()
    {
        if (File.Exists(GlobalConstants.BinarySavePath))
        {
            var loadSteram = new FileStream(GlobalConstants.BinarySavePath, FileMode.Open);

            var data = _formatter.Deserialize(loadSteram) as SaveData;

            loadSteram.Close();

            return data;
        }

        else
            return null;
    }
}
