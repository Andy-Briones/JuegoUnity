using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    public int maxLife = 100;
    private int currentLife;

    public Slider lifeBar;

    void Start()
    {
        currentLife = maxLife;

        lifeBar.maxValue = maxLife;
        lifeBar.value = currentLife;
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;

        lifeBar.value = currentLife;

        if (currentLife <= 0)
        {
            currentLife = 0;

            Die();
        }
    }
    private void Die()
    {
        Boss1 boss = GetComponent<Boss1>();

        if (boss != null)
        {
            boss.Dead();
        }
    }
}
