using UnityEngine;

public class EnemyFast : EnemyBehavior
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void InitializeStats()
    {
        stats = new EnemyStats(1, 5f, 10);
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
