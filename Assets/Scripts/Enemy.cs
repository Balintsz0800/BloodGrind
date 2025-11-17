using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject target;
    Character targetCharacter;
    [SerializeField] float speed;
    
    Rigidbody2D rb;
    
    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = targetDestination.gameObject;
    }

    void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == target)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = target.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
