public interface IGetDamageable
{
    public void TakeDamage(int damage);

    public delegate void HealthOnWallChanged(int hp, int maxHp);
    public event HealthOnWallChanged HealthChangedEvent;
}
