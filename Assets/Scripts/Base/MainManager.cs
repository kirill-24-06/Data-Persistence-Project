using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    [SerializeField] private Text _bestScore;
    [SerializeField] private MainSceneUi _ui;
    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    private int _currentBestPlayer;
    private int _currentPlayerPlace;

    
    // Start is called before the first frame update
    void Start()
    {
        _ui.MenuExit += OnMenuExit;

        _currentBestPlayer = GameData.BestPlayers.Length - 1;
        _currentPlayerPlace = _currentBestPlayer + 1;
        _bestScore.text = "Best Score: " + GameData.BestPlayers[_currentBestPlayer] + ": " + GameData.BestScores[_currentBestPlayer];

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";

        if (m_Points > GameData.BestScores[_currentBestPlayer])
        {
            GameData.SetBestScore(_currentBestPlayer,m_Points);
            GameData.SetBestPlayer(_currentBestPlayer,GameData.CurrentPlayerName);

            _currentPlayerPlace--;
            if (_currentPlayerPlace < 0)
                _currentPlayerPlace = 0;

            _currentBestPlayer--;
            if(_currentBestPlayer < 0)
                _currentBestPlayer = 0;

            _bestScore.text = "Best Score: " + GameData.BestPlayers[_currentBestPlayer] + ": " + GameData.BestScores[_currentBestPlayer];
        }

        else if (_currentPlayerPlace < GameData.BestPlayers.Length)
        {
            if(m_Points > GameData.BestScores[_currentPlayerPlace])
            {
                GameData.SetBestScore(_currentPlayerPlace, m_Points);
            }
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    private void OnMenuExit() => SaveLoad.Save();
   
    private void OnApplicationQuit() => SaveLoad.Save();
}