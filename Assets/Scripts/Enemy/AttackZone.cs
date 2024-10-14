using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
  [SerializeField] private Collider2D _attackZone;
  [SerializeField] private EnemyStrategy strategy;
  private EnemyZoneEnum zone = EnemyZoneEnum.Attack;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
      strategy.EnterZone(zone);
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
      strategy.ExitZone(zone);
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
      strategy.StayZone(zone);
  }
}