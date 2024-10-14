using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyVisual : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  private bool _isDamaged = false;
  private bool _isAttacking = false;
  private bool _isWalking = false;
  private float _positionDifference;
  private bool _isDead = false;
  public static UnityEvent AttackDamageOnEvent = new();
  public static UnityEvent AttackDamageOffEvent = new();


  private const string ENEMY_DEATH = "EnemyDeath";
  private const string POSITION_DIFFERENCE = "PositionDifference";
  private const string IS_DAMAGED = "IsDamaged";
  private const string IS_ATTACKING = "IsAttacking";
  private const string IS_WALKING = "IsWalking";

  public bool IsDamaged => _isDamaged;
  public bool IsAttacking => _isAttacking;
  public bool IsDead => _isDead;
  public bool IsWalking { get => _isWalking; set => _isWalking = value; }
  public float PositionDifference { get => _positionDifference; set => _positionDifference = value; }

  private void Update()
  {
    _animator.SetBool(IS_WALKING, _isWalking);
    _animator.SetFloat(POSITION_DIFFERENCE, _positionDifference);
  }

  internal void StartAnimationDeath()
  {
    _animator.SetTrigger(ENEMY_DEATH);
  }

  private void KillEnemy()
  {
    if (transform.parent != null)
      Destroy(transform.parent.gameObject);
    Destroy(this.gameObject);
  }

  internal void StartAnimationHit()
  {
    if (!_isDamaged && !_isAttacking)
    {
      _isDamaged = true;
      _animator.SetBool(IS_DAMAGED, _isDamaged);
    }
  }

  internal void StartAnimationAttack()
  {
    if (!_isDamaged && !_isAttacking)
    {
      _isAttacking = true;
      _animator.SetBool(IS_ATTACKING, _isAttacking);
      AttackDamageOffEvent.Invoke();
    }
  }

  private void FinishAnimationHit()
  {
    if (_isDamaged)
    {
      _isDamaged = false;
      _animator.SetBool(IS_DAMAGED, _isDamaged);
    }
  }

  private void FinishAnimationAttack()
  {
    if (_isAttacking)
    {
      _isAttacking = false;
      _animator.SetBool(IS_ATTACKING, _isAttacking);
      AttackDamageOffEvent.Invoke();
    }
  }

  private void AttackDamageOn()
  {
    AttackDamageOnEvent.Invoke();
  }

  private void AttackDamageOff()
  {
    AttackDamageOffEvent.Invoke();
  }
}