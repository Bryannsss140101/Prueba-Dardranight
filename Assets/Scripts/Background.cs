using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform img1;
    [SerializeField] private Transform img2;
    [SerializeField] private Transform img3;
    [SerializeField] private Transform pivot;

    private void Update()
    {
        img1.position += speed * Time.deltaTime * (Vector3)Vector2.up;
        img2.position += speed * Time.deltaTime * (Vector3)Vector2.up;
        img3.position += speed * Time.deltaTime * (Vector3)Vector2.up;

        if (img1.position.y >= 20f)
            img1.position = pivot.position;

        if (img2.position.y >= 20f)
            img2.position = pivot.position;

        if (img3.position.y >= 20f)
            img3.position = pivot.position;
    }
}
