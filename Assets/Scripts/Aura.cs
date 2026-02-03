using UnityEngine;

public class Aura : MonoBehaviour
{
    public float damage;
    public float tick;
    float timer;
    private Enemy enemy;
    
    
    void Update()
    {
        if (enemy == null) return;
        timer += Time.deltaTime;

        if (timer >= tick)
        {
            timer = 0f;
            enemy.TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Enemy>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = null;
        }
    }
}
