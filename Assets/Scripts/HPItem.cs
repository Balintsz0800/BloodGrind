using System;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public int HealAmount = 50;
    Transform player;
    public float MaxDistance = 20f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > MaxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Character player = other.GetComponent<Character>();

            if (player != null)
            {
                player.Heal(HealAmount);
            }
            Destroy(gameObject);
        }
    }
}
