using UnityEngine;

public class SettingsScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private EndScreenUI _endScreenUI;
    [SerializeField] private LevelGameEnder _gameEnder;
    private bool _isOpen = false;

    public void CloseOrOpenScreen()
    {
        if (!_gameEnder.isGameContinue) return;

        _endScreen.SetActive(!_isOpen);
        _endScreenUI.ChangeRibbonActive(_isOpen);
        _isOpen = !_isOpen;
    }
}
