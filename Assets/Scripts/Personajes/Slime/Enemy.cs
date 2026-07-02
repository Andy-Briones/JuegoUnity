using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int direction = 1; // 1 = derecha, -1 = izquierda

    public Animator animator;
    private SpriteRenderer sr;

    public int health = 1;
    private bool isDead = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // Voltear sprite según la dirección
        if (direction > 0)
            sr.flipX = false;
        else
            sr.flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().TakeDamage();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
            isDead = true;
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Die");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Destroy(gameObject, 0.5f);
    }
}
