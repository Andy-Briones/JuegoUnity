using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float direction = 1f;

    public void SetDirection(float dir)
    {
        direction = dir;

        if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            BossLife boss = collision.GetComponent<BossLife>();

            if (boss != null)
            {
                boss.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}
