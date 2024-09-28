using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameInputs : MonoBehaviour
{
  private PlayerInputs inputActions;
  public static GameInputs Instance { get; private set; }
  public static UnityEvent jump = new();
  public static UnityEvent attackFirstWeapon = new();
  public static UnityEvent attackSecondWeapon = new();

  private void Awake()
  {
    Instance = this;
    inputActions = new PlayerInputs();
    inputActions.Enable();

    inputActions.Player.Jump.performed += OnJumping;
    inputActions.Player.AttackFirstWeapon.performed += AttackFirstWeapon;
    inputActions.Player.AttackSecondWeapon.performed += AttackSecondWeapon;
  }

  public Vector2 GetMoveVector()
  {
    return inputActions.Player.Move.ReadValue<Vector2>();
  }

  public Vector2 GetMousePosition()
  {
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }

  private void OnJumping(InputAction.CallbackContext context)
  {
    jump.Invoke();
  }

  private void AttackFirstWeapon(InputAction.CallbackContext context)
  {
    attackFirstWeapon.Invoke();
  }

  private void AttackSecondWeapon(InputAction.CallbackContext context)
  {
    attackSecondWeapon.Invoke();
  }
}