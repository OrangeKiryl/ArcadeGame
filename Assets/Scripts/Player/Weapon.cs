using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

  public abstract int GetDamage();

  public abstract void ChangeActiveWeapon();

  public abstract void EnableCollider();

  public abstract void DisableCollider();

  public abstract bool IsActiveWeapon();

  public abstract void MirrorWeapon(bool value);

  private void OnCollisionEnter2D(Collision2D collision)
  {
    GameObject target = collision.gameObject;
    IDamageable targetDamageable = target.GetComponent<IDamageable>();
    targetDamageable?.TakeDamage(GetDamage());
  }

}

public enum WeaponType
{
  Sword,
  Spear
}