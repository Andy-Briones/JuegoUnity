using UnityEngine;
using System.Collections;

public class ZonaDamage : MonoBehaviour
{
    [Header("Configuración")]
    public bool instantKill = false;
    public bool continuousDamage = false;
    public float damageInterval = 1f;

    private Coroutine damageCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerLife vida = other.GetComponent<PlayerLife>();

        if (vida == null)
            return;

        // Muerte instantánea
        if (instantKill)
        {
            vida.InstantKill();
            return;
        }

        // Daño continuo (fuego)
        if (continuousDamage)
        {
            damageCoroutine = StartCoroutine(DamageOverTime(vida));
        }
        else
        {
            // Daño una sola vez (pinchos)
            vida.TakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    IEnumerator DamageOverTime(PlayerLife vida)
    {
        while (true)
        {
            vida.TakeDamage();
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
