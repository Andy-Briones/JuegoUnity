using UnityEngine;

public class player : MonoBehaviour
{
   public enum AttackType
    {
        Ranged,
        Melee
    }

    public float speed = 5;
    private Rigidbody2D rbd;
    private float move;

    public float jumpForce = 4;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    // Doble salto
    public int maxJumps = 2;
    private int jumpCount;

    private Animator animator;

    [Header("Ataque")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    private bool facingRight = true;

    [Header("Melee")]
    public float meleeRange = 1.5f;
    public LayerMask enemyLayer;

    private AttackType attackType;

    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        int personaje = PlayerPrefs.GetInt("Personaje", 0);

        if (personaje == 0)
            attackType = AttackType.Ranged; // mapache
        else
            attackType = AttackType.Melee;  // gato y cuy
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        rbd.linearVelocity = new Vector2(move * speed, rbd.linearVelocity.y);

        // Girar personaje
        if (move != 0)
        {
            Vector3 escalaActual = transform.localScale;
            escalaActual.x = Mathf.Sign(move) * Mathf.Abs(escalaActual.x);
            transform.localScale = escalaActual;

            facingRight = move > 0;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Attack");

            if (attackType == AttackType.Ranged)
            {
                SpawnProjectile();
            }
            else
            {
                MeleeAttack();
            }
        }

        // Salto y doble salto
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rbd.linearVelocity = new Vector2(rbd.linearVelocity.x, jumpForce);
            jumpCount++;
        }

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rbd.linearVelocity.y);
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        // Reiniciar saltos al tocar el suelo
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }
    //Tirar roca
    public void SpawnProjectile()
    {
        GameObject obj = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity);

        Proyectil projectile = obj.GetComponent<Proyectil>();

        projectile.SetDirection(facingRight ? 1 : -1);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
    public void MeleeAttack()
    {
        Vector2 origin = transform.position;
        Vector2 direction = facingRight ? Vector2.right : Vector2.left;

        Vector2 hitPos = origin + direction * meleeRange;

        Collider2D[] hits = Physics2D.OverlapCircleAll(hitPos, 1f, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(10);
            }

            BossLife boss = hit.GetComponent<BossLife>();

            if (boss != null)
            {
                boss.TakeDamage(1);
            }
        }
    }
}