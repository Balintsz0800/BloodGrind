using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    public int Hp = 100; 
    public int currentHp;
    [SerializeField] HealthBar healthBar;

    private void Start()
    {
        currentHp = Hp;
    }

    void Update()
    {
        healthBar.State(currentHp, Hp);
    }
    
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Debug.Log("Game Over! You are dead. :(");
        }
        healthBar.State(currentHp, Hp);
    }
}
