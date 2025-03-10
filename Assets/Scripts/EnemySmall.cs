using UnityEngine;

public class EnemySmall : Enemy
{
    public float horizontalSpeed = 2.0f;
    public float movementRange = 3.0f;
    private float originalX;

    protected override void OnEnable()
    {
        amount = Random.Range(3, maxAmount + 1);
        base.OnEnable();
        originalX = transform.position.x;
    }


    protected override void Move()
    {
        transform.position = new Vector3(originalX + Mathf.Sin(Time.time * horizontalSpeed) * movementRange, transform.position.y, 0);
    }

    protected override void Shoot()
    {
        for (int i = 0; i <= amount; i++)
        {
            var increment = Mathf.Clamp(minDegree + i * segmentSize, minDegree, maxDegree);
            var bullet = ObjectPool.Instance.Get(ObjectType.EnemyBullet).GetComponent<Laser>();

            bullet.Settup(gameObject, speedAttack, increment);
            bullet.transform.position = transform.position;
        }
    }
}