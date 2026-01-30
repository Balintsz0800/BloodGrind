using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    public int Hp = 100; 
    public int currentHp;
    [SerializeField] HealthBar healthBar;
    public GameObject DeathScreen;

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
            Time.timeScale = 0f;
            DeathScreen.SetActive(true);
        }
        healthBar.State(currentHp, Hp);
    }
}
