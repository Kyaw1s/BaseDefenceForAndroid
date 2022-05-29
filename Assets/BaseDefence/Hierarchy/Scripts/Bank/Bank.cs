using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank instance = null;

    public delegate void CoinsCountChanged(object sender, int oldCoinsCount, int newCoinsCount);
    public event CoinsCountChanged CoinsCountChangedEvent;

    private int _coinsCount;
    private int _maxCoinsCount = 9999;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AddCoins(this, GameplayInfoBS.moneyOnStart);
    }

    public void AddCoins(object sender, int delta)
    {
        if (_coinsCount == _maxCoinsCount) return;

        int oldCoinsCount = _coinsCount;
        _coinsCount += delta;

        if (_coinsCount > _maxCoinsCount) _coinsCount = _maxCoinsCount;

        CoinsCountChangedEvent?.Invoke(sender, oldCoinsCount, _coinsCount);
    }

    public void SpendCoins(object sender, int delta)
    {
        if (_coinsCount - delta < 0) throw new Exception("Тратят больше чем есть");

        int oldCoinsCount = _coinsCount;
        _coinsCount -= delta;

        CoinsCountChangedEvent?.Invoke(sender, oldCoinsCount, _coinsCount);
    }
    public bool IsCoinsEnough(int price) => _coinsCount >= price;

}