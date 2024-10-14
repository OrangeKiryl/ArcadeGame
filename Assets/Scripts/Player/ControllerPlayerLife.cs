using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayerLife : MonoBehaviour, IDamageable
{
  [SerializeField] private int _maxHealth;
  [SerializeField] private int _currentHealth;
  [SerializeField] private Collider2D _playerCollider;
  [SerializeField] private PlayerVisual _playerVisual;
  [SerializeField] private Slider _hpSlider;

  private void Start()
  {
    _currentHealth = _maxHealth;
    _hpSlider.maxValue = _maxHealth;
    _hpSlider.value = _currentHealth;
  }

  public int MaxHealth => _maxHealth;

  public int CurrentHealth => _currentHealth;

  public void TakeDamage(int damage)
  {
    if (_currentHealth - damage > 0)
    {
      _currentHealth -= damage;
      _hpSlider.value = _currentHealth;
      _playerVisual.StartAnimationDamaged();
    }
    else
    {
      _currentHealth = 0;
      _hpSlider.value = _currentHealth;
      _playerVisual.StartAnimationDeath();
    }
    Debug.Log(_currentHealth);
    Debug.Log(_hpSlider.value);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "WeaponEnemy")
    {
      TakeDamage(collision.gameObject.GetComponent<WeaponEnemy>().GetDamage());
    }
  }
}