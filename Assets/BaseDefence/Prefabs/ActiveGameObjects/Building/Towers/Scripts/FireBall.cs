using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Tower myTower;
    public delegate void CollisionWithBuilding(IGetDamageable building);
    public event CollisionWithBuilding CollisionWithBuildingEvent;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * myTower.towerData.fireBallSpeed;
        CollisionWithBuildingEvent += myTower.DealDamageToEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            CollisionWithBuildingEvent?.Invoke(enemy);
            Destroy(gameObject);
        }
    }
}
