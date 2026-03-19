using UnityEngine;

public class Knife : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] public float damage;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}