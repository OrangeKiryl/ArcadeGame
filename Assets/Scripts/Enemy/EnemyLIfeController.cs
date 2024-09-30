using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour, IDamageable
{
  [SerializeField] private int _MaxHealth;
  private int _currentHealth;

  public int MaxHealth => _MaxHealth;
  public int CurrentHealth => _currentHealth;

  private void Start()
  {
    _currentHealth = _MaxHealth;
  }

  public void TakeDamage(int damage)
  {
    if (_currentHealth > 0)
    {
      _currentHealth -= damage;
      Debug.Log("Enemy health: " + _currentHealth);
      if (_currentHealth <= 0)
      {
        Debug.Log("Enemy died");
        Animator _animator = GetComponentInChildren<Animator>();
        _animator?.SetTrigger("EnemyDeath");
        //Destroy(gameObject);
      }
    }

  }
}