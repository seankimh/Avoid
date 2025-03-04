using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 25;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();

        if (enemy != null && enemy.gameObject.activeSelf)
        {
            Debug.Log("Bullet hit: " + other.gameObject.name);
            enemy.TakeDamage(damage);
            Destroy(gameObject); //
        }
        else
        {
            Debug.Log("Bullet hit something else: " + other.gameObject.name);
        }
    }
}
