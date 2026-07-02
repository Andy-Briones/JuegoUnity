using UnityEngine;

public class Gaviota : MonoBehaviour
{
    public float velocidadVuelo = 3f;
    public float velocidadCaida = 8f;

    private bool cayendo = false;

    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Al iniciar no tiene gravedad
        rb.gravityScale = 0;
        Destroy(gameObject, 25f);
    }

    void Update()
    {
        // Mientras no caiga, sigue volando
        if (!cayendo)
        {
            transform.Translate(Vector2.right * velocidadVuelo * Time.deltaTime);
        }
    }

    // Este método será llamado por el detector
    public void Caer()
    {
        if (cayendo)
            return;

        cayendo = true;

        animator.SetTrigger("Dive");

        rb.gravityScale = 3;

        Vector2 direccion = new Vector2(0.3f, -1f).normalized;

        rb.linearVelocity = direccion * velocidadCaida;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si toca el suelo desaparece
        if (collision.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject);
        }

        // Si golpea al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife vida = collision.gameObject.GetComponent<PlayerLife>();

            if (vida != null)
            {
                vida.TakeDamage();
            }

            Destroy(gameObject);
        }
    }
}
