using UnityEngine;

public class ManWithBat : Enemy
{
    private void Awake()
    {
        _enemyData = Resources.Load<EnemyData>(EnemiesDataPaths.MAN_WITH_BAT);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Building building))
        {
            StartIdle();
            StartCoroutine(nameof(CR_StartAttacking), building);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Building building))
            StartWalk();
    }

    public override void AE_StartAttack()
    {
        if (target.ToString() == "null") return;
        target.TakeDamage(_enemyData.damage);
    }
}
