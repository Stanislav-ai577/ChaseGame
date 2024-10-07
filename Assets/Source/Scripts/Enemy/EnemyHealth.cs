using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth < 0)
            throw new ArgumentException(nameof(damage), "Damage cannot be negative");
        _currentHealth -= damage;
        Destroy(gameObject);
    }
}
