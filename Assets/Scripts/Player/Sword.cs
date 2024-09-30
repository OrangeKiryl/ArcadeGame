using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sword : Weapon
{
  //public static Sword Instance { get; private set; }
  [SerializeField] private Collider2D _sword;
  //[SerializeField] WeaponType _type;
  [SerializeField] private int _damage;
  [SerializeField] private bool _isActiveWeapon;
  public UnityEvent FinishAttackSword = new();
  public float transfornScaleX;

  //public bool IsActive => _isActiveWeapon;

  //private void Awake()
  //{
  //  Instance = this;
  //}

  private void Start()
  {
    if (_sword != null)
      _sword.enabled = false;
    transfornScaleX = transform.localScale.x;
  }

  public override void EnableCollider()
  {
    _sword.enabled = true;
  }

  public override void DisableCollider()
  {
    _sword.enabled = false;
  }

  public override int GetDamage()
  {
    return _damage;
  }

  //public WeaponType GetWeaponType()
  //{
  //  return _type;
  //}

  public override void ChangeActiveWeapon()
  {
    _isActiveWeapon = !_isActiveWeapon;
  }

  public override bool IsActiveWeapon()
  {
    return _isActiveWeapon;
  }

  public override void MirrorWeapon(bool value)
  {
    if (value)
      transform.localScale = new Vector3(-transfornScaleX, transform.localScale.y, transform.localScale.z);
    else
      transform.localScale = new Vector3(transfornScaleX, transform.localScale.y, transform.localScale.z);
  }
}