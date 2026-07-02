using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int lives = 3;

    private Animator playerAnimator;
    private bool isHurt = false;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        if (lives <= 0)
            return;

        lives--;

        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("Hurt");
        }

        Uimanager.Instance.RomperGema(lives);

        isHurt = true;
        Invoke(nameof(ResetHurt), 0.8f);

        if (lives == 0)
        {
            Uimanager.Instance.MostrarGameOver();
        }
    }

    void ResetHurt()
    {
        isHurt = false;
    }
}
