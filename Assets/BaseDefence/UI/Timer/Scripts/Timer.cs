using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    public event Action<bool> TimeEnd;
    [SerializeField] private TextMeshProUGUI _textUI;
    private float _time = GameplayInfoBS.timeToWinInSeconds;
    private float _updateTime = 1;

    private void Awake()
    {
        _textUI.text = _time.ToString();
        StartCoroutine(nameof(CR_Start));
    }

    private IEnumerator CR_Start()
    {
        while(_time != 0)
        {
            yield return new WaitForSeconds(_updateTime);
            _time -= _updateTime;
            _textUI.text = _time.ToString();
        }
        TimeEnd?.Invoke(true);
    }
}
