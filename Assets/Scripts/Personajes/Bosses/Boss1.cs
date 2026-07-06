using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 2f;
    public float detectionRange = 8f;
    public float attackRange = 2f;

    [Header("Referencias")]
    public Transform player;
    public Transform attackPoint;

    public GameObject groundHitbox;
    public BoxCollider2D groundCollider;
    public BoxCollider2D horizontalCollider;

    [Header("Ataque Horizontal")]
    public float attackRadius = 1f;
    public int attackDamage = 1;
    public LayerMask playerLayer;

    [Header("Ataque al Suelo")]
    public float groundAttackRadius = 6f;
    public int groundAttackDamage = 1;

    public float attackCooldown = 2f;

    private float nextAttackTime = 0f;

    [Header("Wave")]
    public GameObject wavePrefab;
    public Transform[] waveSpawnPoints;

    [Header("VidaBoss")]
    public GameObject vida;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [Header("Orientación")]
    public bool spriteMiraDerecha = false;

    private bool isAttacking = false;
    private bool isDead = false;
    private bool isDefending = false;
    private bool isStunned = false;

    public GameObject panelVictoria;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void BuscarJugador()
    {
        if (player == null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");

            if (jugador != null)
            {
                player = jugador.transform;
            }
        }
    }
    private void CaminarHaciaJugador()
    {
        vida.SetActive(true);
        animator.SetBool("IsWalking", true);

        Vector2 direction = (player.position - transform.position).normalized;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Girar el sprite
        if (direction.x > 0)
        {
            sr.flipX = !spriteMiraDerecha;
        }
        else if (direction.x < 0)
        {
            sr.flipX = spriteMiraDerecha;
        }
    }
    private void AtaqueHorizontal()
    {
        isAttacking = true;

        animator.SetTrigger("AttackHorizontal");

        nextAttackTime = Time.time + attackCooldown;
    }
    private void AtaqueGround()
    {
        isAttacking = true;

        animator.SetTrigger("AttackGround");

        nextAttackTime = Time.time + attackCooldown;
    }
    public void FinAtaque()
    {
        isAttacking = false;
    }
    public void ActivarGroundHitbox()
    {
        groundCollider.enabled = true;
    }
    public void DesactivarGroundHitbox()
    {
        groundCollider.enabled = false;
    }
    public void ActivarHorizontalHitbox()
    {
        horizontalCollider.enabled = true;
    }

    public void DesactivarHorizontalHitbox()
    {
        horizontalCollider.enabled = false;
    }
    public void SpawnWave()
    {
        foreach (Transform punto in waveSpawnPoints)
        {
            Instantiate(
                wavePrefab,
                punto.position,
                Quaternion.identity);
        }
    }
    void Update()
    {
        BuscarJugador();

        if (player == null || isDead || isAttacking || isStunned)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de detección...
        if (distance <= detectionRange)
        {
            // ...pero todavía no está a rango de ataque, caminar.
            if (distance > attackRange)
            {
                CaminarHaciaJugador();
            }
            // Si ya llegó, quedarse quieto.
            else
            {
                animator.SetBool("IsWalking", false);

                if (Time.time >= nextAttackTime)
                {
                    int ataque = Random.Range(0, 2);

                    if (ataque == 0)
                        AtaqueHorizontal();
                    else
                        AtaqueGround();
                }
            }
        }
        else
        {
            // Jugador muy lejos
            animator.SetBool("IsWalking", false);
        }
    }
    public void Dead()
    {
        vida.SetActive(false);
        isDead = true;

        animator.SetTrigger("Die");
        vida.SetActive(false);

        MostrarVictoria();
    }
    private void MostrarVictoria()
    {
        panelVictoria.SetActive(true);
        Time.timeScale = 0f;
    }
}
