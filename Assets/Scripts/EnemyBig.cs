using UnityEngine;

public class EnemyBig : Enemy
{
    public float verticalSpeed = 0.5f;
    public float movementAmplitude = 1.0f;
    private float originalY;

    private float add = 0f;

    protected override void OnEnable()
    {
        amount = Random.Range(3, maxAmount + 1);
        base.OnEnable();
        originalY = transform.position.y;

    }

    protected override void Move()
    {
        float newY = originalY + Mathf.Sin(Time.time * verticalSpeed) * movementAmplitude;
        transform.position = new Vector3(transform.position.x, newY, 0);
    }

    protected override void Shoot()
    {
        if (!canShoot)
            return;

        add += 10;

        for (int i = 0; i < amount; i++)
        {
            var angle = Mathf.Clamp(minDegree + i * segmentSize, minDegree, maxDegree);
            var bullet = ObjectPool.Instance.Get(ObjectType.EnemyBullet).GetComponent<Laser>();
            bullet.Settup(gameObject, speedAttack, angle + add);
            bullet.transform.position = transform.position;
        }
    }
}