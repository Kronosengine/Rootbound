using UnityEngine;

public class FrogAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    private int direction = 1;
    private Rigidbody2D rb;

    [Header("Checks")]
    public Transform groundCheck;
    public Transform wallCheck;
    public Transform playerCheck;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public float groundDistance = 0.2f;
    public float wallDistance = 0.2f;
    public float playerDistance = 1.5f;

    [Header("Attack")]
    public int damage = 1;
    public float attackCooldown = 2f; // время между атаками
    private float attackTimer = 0f;
    private bool attacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;

        DetectPlayer();

        if (!attacking)
            Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        // Проверяем землю и стену
        bool groundAhead = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
        bool wallAhead = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, wallDistance, groundLayer);

        if (!groundAhead || wallAhead)
            Flip();
    }

    void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, Vector2.right * direction, playerDistance, playerLayer);

        if (hit.collider != null && attackTimer <= 0f)
        {
            Attack(hit.collider.gameObject);
        }
    }

    void Attack(GameObject player)
    {
        attacking = true;

        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Debug.Log("Лягушка нанесла урон!");
        }

        attackTimer = attackCooldown; // сброс таймера атаки
        Invoke("StopAttack", 1f);     // враг завершает атаку через секунду
    }

    void StopAttack()
    {
        attacking = false;
    }

    void Flip()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Для наглядности можно добавить Gizmos
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundDistance);
        if (wallCheck != null)
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * direction * wallDistance);
        if (playerCheck != null)
            Gizmos.DrawLine(playerCheck.position, playerCheck.position + Vector3.right * direction * playerDistance);
    }
}