using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IHandle
{
    private Animator animator;

    public void Handle()
    {
        if (animator == null)
            return;

        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        animator.SetFloat("Direction X", direction.x);
    }

    private void Start()
    {
        animator ??= GetComponent<Animator>();
    }
}