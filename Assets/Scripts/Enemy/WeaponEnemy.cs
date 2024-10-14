using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
  [SerializeField] private int _damage;

  public int GetDamage() => _damage;
}