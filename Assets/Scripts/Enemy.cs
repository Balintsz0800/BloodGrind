using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    Character targetCharacter;
    public float speed;
    
    Rigidbody2D rb;
    
    [SerializeField] public float hp = 4;
    [SerializeField] int damage = 1;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
            targetCharacter = playerObj.GetComponent<Character>();
        }
    }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (target != null && collision.gameObject == target.gameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter != null)
        {
            targetCharacter.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}