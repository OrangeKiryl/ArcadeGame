using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  private bool _isAttacking;

  private void Start()
  {
    GameInputs.attackFirstWeapon.AddListener(AttackFirstWeapon);
  }

  private void Update()
  {
 
  }

  private void AttackFirstWeapon()
  {
    if (!_isAttacking)
    {
      _isAttacking = true;
      _animator.SetBool("AttackFirstWeapon", _isAttacking);
    }
  }

  private void FinishAttackFirstWeapon()
  {
    if (_isAttacking)
    {
      _isAttacking = false;
      _animator.SetBool("AttackFirstWeapon", _isAttacking);
    }
  }
}