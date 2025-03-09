using UnityEngine;

public class PlayerMovement : MonoBehaviour, IHandle
{
    [SerializeField] private float speed;

    private Vector3 velocity;
    private Vector2 direction;

    public void Handle()
    {
        Translate();
    }

    private void Translate()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        velocity = speed * Time.deltaTime * direction;

        transform.position += velocity;
    }
}