using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IGetDamageable
{
    public event IGetDamageable.HealthOnWallChanged HealthChangedEvent;

    protected delegate void State();
    protected State _stateWhenDisposableAnimationPlaying = null;
    protected EnemyData _enemyData;
    protected AnimationControllerForEnemy _animationController;
    private Rigidbody2D _rigidbody2D;

    private int _currentHP;
    protected IGetDamageable target;

    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animationController = new AnimationControllerForEnemy(GetComponent<Animator>());

        _currentHP = _enemyData.maxHP;
        StartWalk();
    }


    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        HealthChangedEvent?.Invoke(_currentHP, _enemyData.maxHP);
        if (_currentHP <= 0) _animationController.ChangeAnimation(AnimationNamesForEnemy.DEATH);
        _animationController.ChangeAnimation(AnimationNamesForEnemy.HURT);
    }

    public void AE_Destroy()
    {
        Destroy(gameObject);
        Bank.instance.AddCoins(this, _enemyData.coinsRewardAfterDeath);
    }

    public void AE_InstallZeroToVelocity() => _rigidbody2D.velocity = Vector2.zero;

    public void AE_InstallZeroToAnimationPriority() => _animationController.currentPriority = 0;

    public void AE_BackVelocityToNormalState()
    {
        if(!_animationController.GetIsAttacking()) _rigidbody2D.velocity = Vector2.left * _enemyData.speed;
    }

    public abstract void AE_StartAttack();
    protected void StartWalk()
    {
        _animationController.SetIsAttacking(false);
        _animationController.ChangeAnimation(AnimationNamesForEnemy.WALK);
        _rigidbody2D.velocity = Vector2.left * _enemyData.speed;
    }
    protected void StartIdle()
    {
        _animationController.SetIsAttacking(true);
        _animationController.ChangeAnimation(AnimationNamesForEnemy.IDLE);
        _rigidbody2D.velocity = Vector2.zero;
    }

    protected IEnumerator CR_StartAttacking(IGetDamageable getDamageable)
    {
        target = getDamageable;
        while (_animationController.GetIsAttacking())
        {
            yield return new WaitForSeconds(_enemyData.timeBetweenAttack);
            if (target.ToString() == "null") break;
            _animationController.ChangeAnimation(AnimationNamesForEnemy.ATTACK);
        }
    }
}
