using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

public class PlayerVisual : MonoBehaviour
{
  [SerializeField] private Animator _animator;

  private const string INPUT_X = "InputX";
  private const string POSITION_DIFFERENCE_X = "positionDifferenceX";
  private const string IS_RUNNING = "IsRunning";
  private const string ON_JUMPING = "OnJumping";
  private const string ANIMATION_MIRROR = "AnimationMirror";

  public static UnityEvent FinishAttackFirstWeapon = new();

  private void Start()
  {
    GameInputs.jump.AddListener(OnJumping);
  }

  private void Update()
  {
    _animator.SetFloat(POSITION_DIFFERENCE_X, Player.Instance.GetPlayerPosition().x - GameInputs.Instance.GetMousePosition().x);
    _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
    _animator.SetFloat(INPUT_X, GameInputs.Instance.GetMoveVector().x);
    _animator.SetFloat(ANIMATION_MIRROR, AnimationMirror());
  }

  private void OnJumping()
  {
    if (Player.Instance.IsGrounded())
    {
      _animator.SetBool(ON_JUMPING, true);
    }
  }

  private void FinishJump()
  {
    _animator.SetBool(ON_JUMPING, false);
  }

  private float AnimationMirror()
  {
    if (Player.Instance.IsRunning())
      return Player.Instance.GetMoveDirection().x;
    return GameInputs.Instance.GetMousePosition().x - Player.Instance.GetPlayerPosition().x;
  }

  public void SetAnimatorParametr(PlayerAnimatorParameter param, bool value)
  {
    _animator.SetBool(param.ToString(), value);
  }

  public void SetAnimatorParametr(PlayerAnimatorParameter param, float value)
  {
    _animator.SetFloat(param.ToString(), value);
  }

  private void FinishAttacFirstWeapon()
  {
    _animator.SetBool("AttackFirstWeapon", false);
    FinishAttackFirstWeapon.Invoke();
  }
}

public enum PlayerAnimatorParameter
{
  InputX,
  PositionDifferenceX,
  IsRunning,
  OnJumping,
  AnimationMirror,
  AttackFirstWeapon
}