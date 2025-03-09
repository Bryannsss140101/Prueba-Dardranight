using UnityEngine;

public class PlayerAttack : MonoBehaviour, IHandle
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private float speed;

    public void Handle()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var temp = ObjectPool.Instance.Get(ObjectType.PlayerBullet);
            temp.GetComponent<Bullet>().Settup(gameObject, speed, Vector2.up);
            temp.transform.position = muzzle.position;
        }
    }
}