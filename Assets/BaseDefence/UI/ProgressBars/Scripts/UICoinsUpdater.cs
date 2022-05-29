using TMPro;
using UnityEngine;

public class UICoinsUpdater : MonoBehaviour
{
    private TextMeshProUGUI _CoinsCountText;

    private void Start()
    {
        _CoinsCountText = GetComponent<TextMeshProUGUI>();

        Bank.instance.CoinsCountChangedEvent += OnCoinsCountChanged;
    }

    private void OnCoinsCountChanged(object sender, int oldCoinsCount, int newCoinsCount)
    {
        _CoinsCountText.text = newCoinsCount.ToString();
    }
}
