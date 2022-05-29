using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelGameEnder : MonoBehaviour
{
    public bool isGameContinue { get; private set; }
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private EndScreenUI _endScreenUI;
    [SerializeField] private Timer timerToWin;

    private void Start()
    {
        isGameContinue = true;
        timerToWin.TimeEnd += EndGame;
    }

    public void EndGame(bool isWin)
    {
        _endScreenUI.ChangeRibbonActive(true);
        if (isWin)
        {
            StarsInfoBS.AddStarsInfo(GameplayInfoBS.level, 3);
            _endScreenUI.ChangeText("Победа!");
            _endScreenUI.ChangeRibbonColor(Color.green);
        }
        else
        {
            _endScreenUI.ChangeText("Поражение!");
            _endScreenUI.ChangeRibbonColor(Color.red);
        }
        isGameContinue = false;
        _endScreen.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)ScenesIndexes.MainMenu);
    }
}


enum ScenesIndexes
{
    MainMenu = 0,
    FirstLevel = 1
}
