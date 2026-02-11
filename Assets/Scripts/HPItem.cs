using System;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public int HealAmount = 50;

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
