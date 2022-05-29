using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "Gameplay/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int _maxHP;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenAttack;
    [SerializeField] private int _coinsRewardAfterDeath;

    public int maxHP => _maxHP;
    public int damage => _damage;
    public float speed => _speed;
    public float timeBetweenAttack => _timeBetweenAttack;
    public int coinsRewardAfterDeath => _coinsRewardAfterDeath;
}

public class AnimationNamesForEnemy
{
    public static readonly string ATTACK = "Attack";
    public static readonly string DEATH = "Death";
    public static readonly string HURT = "Hurt";
    public static readonly string IDLE = "Idle";
    public static readonly string WALK = "Walk";
}

public class EnemiesDataPaths
{
    public static readonly string MAN_WITH_BAT = "ManWithBat";
    public static readonly string TANK = "Tank";
}
