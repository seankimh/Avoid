public struct EnemyStats
{
    public int health;
    public float speed;
    public int damage;

    public EnemyStats(int health, float speed, int damage) // Ensure the order is correct!
    {
        this.health = health;
        this.speed = speed;
        this.damage = damage;
    }
}
