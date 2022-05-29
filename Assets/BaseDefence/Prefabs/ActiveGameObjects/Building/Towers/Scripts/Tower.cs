using UnityEngine;

public class Tower : Building, IGetDamageable, IImproving
{
    public event IGetDamageable.HealthOnWallChanged HealthChangedEvent;

    [SerializeField] private GameObject _fireBall;
    [SerializeField] private AnimationClip _clip;
    [SerializeField] private Transform _placeForFireBalls;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private const string WORK_SPEED = "WorkSpeed";
    public TowerData towerData { get; private set; }

    private void OnEnable()
    {
        _dataPathsWithLevels = new string[]
        {
            TowersDataPath.LEVEL_1,
            TowersDataPath.LEVEL_2,
            TowersDataPath.LEVEL_3
        };

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _animator = GetComponent<Animator>();
        ChangeLevel(_currentLevel);
        buildingNextLevelData = GetNextLevelData();
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0) Destroy();

        HealthChangedEvent?.Invoke(_currentHP, towerData.maxHP);
    }

    public void DealDamageToEnemy(IGetDamageable enemy) => enemy.TakeDamage(towerData.damage);


    public override BuildingData GetNextLevelData()
    {
        if (HaveImproveToNextLevel()) return Resources.Load<TowerData>(_dataPathsWithLevels[GetIndex(_currentLevel + 1)]);
        return null;
    }

    protected override void ChangeLevel(int level)
    {
        string towerPath = _dataPathsWithLevels[GetIndex(level)];
        towerData = Resources.Load<TowerData>(towerPath);

        _spriteRenderer.sprite = towerData.sprite;
        ChangeAnimationSpeed(towerData.timeBetweenAttack);

        InitializeBuilding<TowerData>(towerData, level);

        HealthChangedEvent?.Invoke(_currentHP, towerData.maxHP);
    }

    private void AE_Attack()
    {
        FireBall fireBall = Instantiate(_fireBall, _placeForFireBalls.position, _fireBall.transform.rotation, transform).GetComponent<FireBall>();
        fireBall.myTower = this;
    }

    private void ChangeAnimationSpeed(float length)
    {
        _animator.SetFloat(WORK_SPEED, GetSpeedForAnimation(length));
    }

    private float GetSpeedForAnimation(float length) => _clip.length / length;

}
