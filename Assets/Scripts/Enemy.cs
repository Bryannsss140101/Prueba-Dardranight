using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    [Header("Enemy Attack")]
    [SerializeField] protected float speed;
    [SerializeField] protected float delay;
    [SerializeField][Range(0f, 360f)] protected float minDegree;
    [SerializeField][Range(0f, 360f)] protected float maxDegree;

    protected int amount;
    protected float segments;
    private bool canShoot;

    public bool IsDeath => health <= 0;

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

        CancelInvoke(nameof(Shoot));
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (IsDeath)
            Death();
    }

    private void OnEnable()
    {
        amount = Random.Range(3, 6);
        segments = (maxDegree - minDegree) / amount;

        InvokeRepeating(nameof(Shoot), 0f, delay);
    }

    protected abstract void Shoot();
}