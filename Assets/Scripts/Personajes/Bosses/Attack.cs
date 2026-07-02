using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife vida = other.GetComponent<PlayerLife>();

            if (vida != null)
            {
                vida.TakeDamage();
            }
        }
    }
}
