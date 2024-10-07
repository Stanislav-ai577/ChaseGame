using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;
    
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth < 0)
            throw new ArgumentException(nameof(_currentHealth), "Damage cannot be negative");
        _currentHealth -= damage;
        OnDie?.Invoke();
        Destroy(gameObject);
    }
}
