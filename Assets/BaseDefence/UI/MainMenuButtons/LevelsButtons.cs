using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsButtons : MonoBehaviour
{
    [SerializeField] private int _level;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(InstallGameplayValuesAndLoadLevel);
    }

    private void InstallGameplayValuesAndLoadLevel()
    {
        LevelInfo levelInfo = Resources.Load<LevelInfo>(LevelInfoPaths.GetPath(_level));
        GameplayInfoBS.InstallValues(levelInfo.timeToWinInSeconds, levelInfo.timeBetweenEnemySpawn, levelInfo.moneyOnStart, _level);
        SceneManager.LoadScene((int)ScenesIndexes.FirstLevel);
    }
}
