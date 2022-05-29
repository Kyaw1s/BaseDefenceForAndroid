using UnityEngine;

public class Tank : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    private void Awake()
    {
        _enemyData = Resources.Load<EnemyData>(EnemiesDataPaths.TANK);
    }

    public override void AE_StartAttack()
    {
        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation, transform).GetComponent<BulletForTank>().myTank = this;
    }

    public void StartAttacking(Building building)
    {
        StartIdle();
        StartCoroutine(nameof(CR_StartAttacking), building);
    }

    public void EndAttacking() => StartWalk();


    public void DealDamageToTarget(IGetDamageable target)
    {
        if (target.ToString() == "null") return;
        target.TakeDamage(_enemyData.damage);
    }

}
