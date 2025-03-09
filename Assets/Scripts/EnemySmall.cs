using UnityEngine;

public class EnemySmall : Enemy
{
    protected override void Shoot()
    {
        for (int i = 0; i <= amount; i++)
        {
            var increment = Mathf.Clamp(minDegree + i * segments, minDegree, maxDegree);
            var bullet = ObjectPool.Instance.Get(ObjectType.EnemyBullet).GetComponent<Bullet>();

            bullet.Settup(gameObject, speed, increment);
            bullet.transform.position = transform.position;
        }
    }
}