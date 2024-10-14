using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour, IDamageable
{
  [SerializeField] private int _maxHealth;
  [SerializeField] private EnemyVisual _enemyVisual;
  [SerializeField] private GameObject _weapon;
  private Collider2D _weaponCollider;
  private int _currentHealth;

  public int MaxHealth => _maxHealth;
  public int CurrentHealth => _currentHealth;

  private void Start()
  {
    _currentHealth = _maxHealth;
    _weaponCollider = _weapon.GetComponent<Collider2D>();
    _weaponCollider.enabled = false;
    EnemyVisual.AttackDamageOnEvent.AddListener(OnWeaponCollider);
    EnemyVisual.AttackDamageOffEvent.AddListener(OffWeaponCollider);
  }

  public void TakeDamage(int damage)
  {
    if (_currentHealth > 0)
    {
      if (!_enemyVisual.IsDamaged && !_enemyVisual.IsAttacking)
      {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
          _enemyVisual.StartAnimationDeath();
        }
        else
        {
          _enemyVisual.StartAnimationHit();
        }
      }
    }
  }

  public void Attack()
  {
    if (_currentHealth > 0)
    {
      if (!_enemyVisual.IsDamaged && !_enemyVisual.IsAttacking)
      {
        _enemyVisual.StartAnimationAttack();
      }
    }
  }

  private void OnWeaponCollider()
  { 
    if (transform.position.x > Player.Instance.GetPlayerPosition().x)
    {
      _weapon.transform.localScale = new Vector3(-1, _weapon.transform.localScale.y, _weapon.transform.localScale.z);
    }
    _weaponCollider.enabled = true;
  }

  private void OffWeaponCollider()
  {
    _weaponCollider.enabled = false;
    _weapon.transform.localScale = new Vector3(1, _weapon.transform.localScale.y, _weapon.transform.localScale.z);
  }
}