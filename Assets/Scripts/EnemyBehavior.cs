using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    protected EnemyStats stats;
    protected Transform player;
    public int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        InitializeStats();
        currentHealth = stats.health;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (isDead || player == null) return;
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer() { }

    public virtual void InitializeStats() { }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (isDead) return;

        isDead = true;
        GameManager.Instance?.EnemyDied(gameObject);
        gameObject.SetActive(false);
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance?.GameOver();
            Destroy(other.gameObject);
        }
    }
}
