
public static class GameData
{
    private static string _currentPlayerName = "Player1";
    public static string CurrentPlayerName => _currentPlayerName;

    private static string[] _bestPlayers = new string[5];
    public static string[] BestPlayers => _bestPlayers;

    private static int[] _bestScore = new int[5];
    public static int[] BestScores => _bestScore;


    public static void SetName(string newName) => _currentPlayerName = newName;

    public static void SetBestPlayer(int index, string newName) => _bestPlayers[index] = newName;

    public static void SetBestScore(int index, int newScore) => _bestScore[index] = newScore;
    
}