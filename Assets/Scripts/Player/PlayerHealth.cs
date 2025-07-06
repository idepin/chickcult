using System;
using NaughtyAttributes;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth = 1f;
    private float health = 1f;

    public Action<float> onHealthChanged;

    void Start()
    {
        health = maxhealth; // Initialize health to max health
    }

    [Button]
    public void TestDamage()
    {
        Damage(0.1f);
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        onHealthChanged?.Invoke(health);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxhealth)
        {
            health = maxhealth; // Prevent overhealing
        }
        onHealthChanged?.Invoke(health);
    }
    public void Die()
    {
        // Handle player death logic here
        Debug.Log("Player has died.");
        // You can add more logic like respawning, playing death animation, etc.
        //gameObject.SetActive(false); // Disable the player object for now
    }
}
