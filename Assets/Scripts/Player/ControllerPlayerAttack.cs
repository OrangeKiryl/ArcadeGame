using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerAttack : MonoBehaviour
{
  [SerializeField] private PlayerVisual _playerVisual;
  [SerializeField] private List<Weapon> weapons;
  private bool _isAttacking;

  private void Start()
  {
    GameInputs.attackFirstWeapon.AddListener(AttackFirstWeapon);
    PlayerVisual.FinishAttackFirstWeapon.AddListener(FinishAttackFirstWeapon);
    _isAttacking = false;
  }

  private void AttackFirstWeapon()
  {
    if (!_isAttacking)
    {
      foreach (Weapon weapon in weapons)
      {
        if (weapon.IsActiveWeapon())
        {
          _isAttacking = true;
          if (Player.Instance.GetPlayerPosition().x > GameInputs.Instance.GetMousePosition().x)
          {
            weapon.MirrorWeapon(true);
          }
          weapon.EnableCollider();
          _playerVisual.SetAnimatorParametr(PlayerAnimatorParameter.AttackFirstWeapon, true);
        }
      }
    }
  }

  private void FinishAttackFirstWeapon()
  {
    if (_isAttacking)
    {
      _isAttacking = false;
      foreach (Weapon weapon in weapons)
      {
        if (weapon.IsActiveWeapon())
        {
          weapon.DisableCollider();
          weapon.MirrorWeapon(false);
        }
      }
    }
  }
}