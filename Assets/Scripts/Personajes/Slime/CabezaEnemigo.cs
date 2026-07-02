using UnityEngine;

public class CabezaEnemigo : MonoBehaviour
{
    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.Die();

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 4f);
            }
        }
    }
}
