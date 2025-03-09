public interface IDamageable
{
    public bool IsDeath { get; }

    public void TakeDamage(int damage);

    public void Death();
}