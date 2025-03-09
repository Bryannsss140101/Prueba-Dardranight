using UnityEngine;

public class PlayerStats : MonoBehaviour, IHandle, IDamageable
{
    [SerializeField] private int health;

    private int shield;
    private int level;

    public bool IsDeath => health <= 0;

    public void Handle()
    {
        if (IsDeath)
            Death();
    }

    public void TakeDamage(int damage)
    {
        if (IsDeath)
            return;

        health -= damage;
    }

    public void Death()
    {
        var obj = ObjectPool.Instance.Get(ObjectType.Explotion);
        obj.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}