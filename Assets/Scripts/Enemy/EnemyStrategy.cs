using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrategy : MonoBehaviour
{
  [SerializeField] private EnemyMovementController _movContr;
  [SerializeField] private EnemyVisual _enemyVisual;
  [SerializeField] private EnemyLifeController _enemyLifeController;
  private EnemyStrategyEnum _enemyStrategy = EnemyStrategyEnum.Wandering;
  public EnemyStrategyEnum CurrentStrategy => _enemyStrategy;


  private void Start()
  {

  }

  private void Wandering()
  {
    _enemyStrategy = EnemyStrategyEnum.Wandering;
    _movContr.FinishAllCoroutines();
    _movContr.StartWalkingCoroutine();
  }

  private void Chasing()
  {
    _enemyStrategy = EnemyStrategyEnum.Chasing;
    _movContr.FinishAllCoroutines();
    _movContr.StartChasingCoroutine();
  }

  private void Attacking()
  {
    if (!_enemyVisual.IsAttacking && !_enemyVisual.IsDamaged)
    {
      _enemyStrategy = EnemyStrategyEnum.Attacking;
      _movContr.FinishAllCoroutines();
      _enemyLifeController.Attack();
    }
  }

  public void EnterZone(EnemyZoneEnum zone)
  {
    if (_enemyVisual.IsDead) return;
    switch (_enemyStrategy)
    {
      case EnemyStrategyEnum.Wandering:
        switch (zone)
        {
          case EnemyZoneEnum.Aggro:
            Chasing();
            break;

          case EnemyZoneEnum.Attack:
            Attacking();
            break;
        }
        break;

      case EnemyStrategyEnum.Chasing:
        if (zone == EnemyZoneEnum.Attack)
        {
          Attacking();
        }
        break;
    }
  }

  public void ExitZone(EnemyZoneEnum zone)
  {
    switch (_enemyStrategy)
    {
      case EnemyStrategyEnum.Attacking:
        switch (zone)
        {
          case EnemyZoneEnum.Attack:
            Chasing();
            break;

          case EnemyZoneEnum.Aggro:
            Wandering();
            break;
        }
        break;

      case EnemyStrategyEnum.Chasing:
        if (zone == EnemyZoneEnum.Aggro)
        {
          Wandering();
        }
        break;
    }
  }

  public void StayZone(EnemyZoneEnum zone)
  {
    switch (_enemyStrategy)
    {
      case EnemyStrategyEnum.Attacking:
        switch (zone)
        {
          case EnemyZoneEnum.Attack:
            Attacking();
            break;
        }
        break;

      case EnemyStrategyEnum.Chasing:
        switch (zone)
        {
          case EnemyZoneEnum.Aggro:
            Chasing();
            break;
        }
        break;
    }
  }
}

public enum EnemyStrategyEnum
{
  Wandering,
  Chasing,
  Attacking
}

public enum EnemyZoneEnum
{
  Aggro,
  Attack
}