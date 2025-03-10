using UnityEngine;

public class PlayerMovement : MonoBehaviour, IHandle
{
    [SerializeField] private float speed;

    private Vector3 velocity;
    private Vector2 direction;

    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

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

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth, mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - objectWidth);
        float lowerBound = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight;
        float upperBound = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - objectHeight;
        viewPos.y = Mathf.Clamp(viewPos.y, lowerBound, upperBound);

        transform.position = viewPos;
    }
}