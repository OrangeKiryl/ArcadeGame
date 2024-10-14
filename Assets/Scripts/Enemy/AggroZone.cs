using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroZone : MonoBehaviour
{
  [SerializeField] private Collider2D _aggroZone;
  [SerializeField] private EnemyStrategy strategy;
  private EnemyZoneEnum zone = EnemyZoneEnum.Aggro;

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
}