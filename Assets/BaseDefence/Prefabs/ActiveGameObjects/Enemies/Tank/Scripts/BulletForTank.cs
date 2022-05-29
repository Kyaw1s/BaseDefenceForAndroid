using UnityEngine;

public class BulletForTank : MonoBehaviour
{
    [HideInInspector] public Tank myTank;
    public delegate void CollisionWithBuilding(IGetDamageable target);
    public CollisionWithBuilding CollisionWithBuildingEvent;
    private float _speed = 22f;

    private void Start()
    {
        CollisionWithBuildingEvent += myTank.DealDamageToTarget;
        GetComponent<Rigidbody2D>().velocity = Vector2.left * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Building building))
        {
            CollisionWithBuildingEvent?.Invoke(building.GetComponent<IGetDamageable>());
            Destroy(gameObject);
        }
    }
}
