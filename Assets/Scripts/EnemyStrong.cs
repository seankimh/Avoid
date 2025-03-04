using UnityEngine;

public class EnemyStrong : EnemyBehavior
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void InitializeStats()
    {
        stats = new EnemyStats(2, 2f, 20);
    }

    protected override void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * stats.speed;
        }
    }
}
