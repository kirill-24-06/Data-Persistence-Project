
public static class GameData
{
    private static string _currentPlayerName = "Player1";
    public static string CurrentPlayerName => _currentPlayerName;

    private static string _bestPlayer = "Joe";
    public static string BestPlayer => _bestPlayer;

    private static int _bestScore = 0;
    public static int BestScore => _bestScore;


    public static void SetName(string newName) => _currentPlayerName = newName;

    public static void NewBestPlayer(string newName) => _bestPlayer = newName;

    public static void NewBestScore(int newScore)
    {
        if (newScore > _bestScore)
            _bestScore = newScore;
    }
}