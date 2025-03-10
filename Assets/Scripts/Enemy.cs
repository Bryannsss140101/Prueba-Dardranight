using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    [Header("Enemy Attack")]
    [SerializeField] protected float speedAttack;
    [SerializeField] protected float delay;
    [SerializeField][Range(1f, 10f)] protected int maxAmount;
    [SerializeField][Range(0f, 360f)] protected float minDegree;
    [SerializeField][Range(0f, 360f)] protected float maxDegree;
    [SerializeField] private float elapse;

    private int auxHealth;

    protected int amount;
    protected float segmentSize;
    protected bool canShoot;

    [Header("Enemy Movement")]
    [SerializeField] protected float speed;
    protected Vector3 velocity;
    protected Vector2 direction;

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

    private void Awake()
    {
        auxHealth = health;
    }

    protected virtual void OnEnable()
    {
        direction = Vector2.right;
        health = auxHealth;
        segmentSize = (maxDegree - minDegree) / amount;
        InvokeRepeating(nameof(Shoot), 2.5f, delay);
        InvokeRepeating(nameof(Elapsed), 0f, elapse);
    }

    protected virtual void OnDisable()
    {
        CancelInvoke(nameof(Shoot));
        CancelInvoke(nameof(Elapsed));
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (IsDeath)
            Death();

        Move();
    }

    protected abstract void Shoot();

    protected abstract void Move();

    private void Elapsed()
    {
        canShoot = !canShoot;
    }
}