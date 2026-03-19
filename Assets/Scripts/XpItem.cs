using System;
using UnityEngine;

public class XpItem : MonoBehaviour
{
    public int XpAmount = 5;
    Transform player;
    public float MaxDistance = 40f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > MaxDistance)
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
                player.AddXp(XpAmount);
            }
            Destroy(gameObject);
        }
    }
}
