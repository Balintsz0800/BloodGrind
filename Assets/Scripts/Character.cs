using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;
    [SerializeField] HealthBar healthBar;

    public int level = 1;
    public int currentXp = 0;
    public int xpToNextLevel = 15;

    public SelectedWeaponUpgrade WeaponUpgrade;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void Heal(int amount)
    {
        currentHp += amount;

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }

    public void AddXp(int amount)
    {
        currentXp += amount;

        if (currentXp >= xpToNextLevel)
        {
            level++;
            currentXp = 0;
            xpToNextLevel += 10;
            
            WeaponUpgrade.Upgrade();
        }
    }

    void Update()
    {
        healthBar.State(currentHp, maxHp);
    }
    
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Time.timeScale = 0f;
            UIManager.instance.DeathScreen();
        }
        healthBar.State(currentHp, maxHp);
    }
}