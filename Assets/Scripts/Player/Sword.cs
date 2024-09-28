using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sword : MonoBehaviour
{
  [SerializeField] private Collider2D _sword;
  public static UnityEvent _finishAttackFirstWeapon = new();

  private void Start()
  {
    GameInputs.attackFirstWeapon.AddListener(EnableCollider);
  }

  private void EnableCollider()
  {
    _sword.enabled = true;
  }
}