using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private Vector3 velocity;
    private Vector2 direction;
    private GameObject owner;

    public void Settup(GameObject owner, float speed, float angle)
    {
        this.owner = owner;
        this.speed = speed;

        angle *= Mathf.Deg2Rad;
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        direction = new(x, y);
    }

    public void Settup(GameObject owner, float speed, Vector2 direction)
    {
        this.owner = owner;
        this.speed = speed;
        this.direction = direction;
    }

    private void Update()
    {
        Translate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (owner == collision.gameObject)
            return;

        if (collision.CompareTag("Entity"))
        {
            var entity = collision.GetComponent<IDamageable>();
            entity.TakeDamage(1);
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void Translate()
    {
        velocity = speed * Time.deltaTime * direction;
        transform.position += velocity;
    }
}