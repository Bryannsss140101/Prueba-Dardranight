using UnityEngine;

public enum PlayerType { Level1, Level2, Level3 }

public class PlayerController : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    private PlayerStats playerStats;

    private void Start()
    {
        playerAnimation ??= GetComponent<PlayerAnimation>();
        playerMovement ??= GetComponent<PlayerMovement>();
        playerAttack ??= GetComponent<PlayerAttack>();
        playerStats ??= GetComponent<PlayerStats>();
    }

    private void Update()
    {
        playerAnimation.Handle();
        playerMovement.Handle();
        playerAttack.Handle();
        playerStats.Handle();
    }
}