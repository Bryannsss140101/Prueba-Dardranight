using UnityEngine;

public class EnemyMedium : Enemy
{
    public float waveFrequency = 5.0f;
    public float waveMagnitude = 0.5f;
    private float originalX;

    protected override void OnEnable()
    {
        amount = Random.Range(10, (maxAmount + 1) * 10);
        base.OnEnable();
        originalX = transform.position.x;
    }

    protected override void Move()
    {
        transform.position = new Vector2(originalX + Mathf.Sin(Time.time * waveFrequency) * waveMagnitude, transform.position.y - speed * Time.deltaTime);
    }

    protected override void Shoot()
    {
        if (!canShoot)
            return;

        for (int i = 0; i <= amount; i++)
        {
            var increment = Mathf.Clamp(minDegree + i * segmentSize, minDegree, maxDegree);
            var bullet = ObjectPool.Instance.Get(ObjectType.EnemyBullet).GetComponent<Laser>();

            bullet.Settup(gameObject, speedAttack, increment);
            bullet.transform.position = transform.position;
        }
    }
}