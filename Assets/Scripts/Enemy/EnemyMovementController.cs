using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[SelectionBase]
public class EnemyMovementController : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private float _speed;
  [SerializeField] private float _minDistance;
  [SerializeField] private float _maxDistance;
  [SerializeField] private float _waitTime;
  [SerializeField] private EnemyStrategy _strategy;
  [SerializeField] private EnemyVisual enemyVisual;
  private float _startXPosition;
  private float _xPosition;
  private Coroutine _walking;
  private Coroutine _chasing;

  private void Start()
  {
    _startXPosition = transform.position.x;
    GetNewXPosition();
    enemyVisual.PositionDifference = _rb.position.x - _xPosition;
    StartWalkingCoroutine();
  }

  private void GetNewXPosition()
  {
    if (_xPosition >= _startXPosition)
      _xPosition = _startXPosition - Random.Range(_minDistance, _maxDistance);
    else
      _xPosition = _startXPosition + Random.Range(_minDistance, _maxDistance);
  }

  private IEnumerator Walking()
  {
    while (gameObject.activeInHierarchy && transform.parent != null && _strategy.CurrentStrategy == EnemyStrategyEnum.Wandering)
    {
      if (Mathf.Abs(_rb.position.x - _xPosition) < 0.1f)
      {
        GetNewXPosition();
        enemyVisual.IsWalking = false;
        yield return new WaitForSeconds(_waitTime);
      }

      if (_rb.position.x < _xPosition)
        _rb.MovePosition(_rb.position + new Vector2(_speed * Time.deltaTime, 0));
      else
        _rb.MovePosition(_rb.position - new Vector2(_speed * Time.deltaTime, 0));
      enemyVisual.IsWalking = true;

      enemyVisual.PositionDifference = _rb.position.x - _xPosition;

      yield return null;
    }
  }

  internal void FinishAllCoroutines()
  {
    if (_walking != null)
      StopCoroutine(_walking);

    if (_chasing != null)
      StopCoroutine(_chasing);

    enemyVisual.IsWalking = false;
  }

  internal void StartWalkingCoroutine()
  {
    if (gameObject.activeInHierarchy && transform.parent != null && _strategy.CurrentStrategy == EnemyStrategyEnum.Wandering)
    {
      enemyVisual.IsWalking = true;
        _walking = StartCoroutine(Walking());
    }
  }

  internal void StartChasingCoroutine()
  {
    if (gameObject.activeInHierarchy && transform.parent != null && _strategy.CurrentStrategy == EnemyStrategyEnum.Chasing)
    {
      enemyVisual.IsWalking = true;
        _chasing = StartCoroutine(Chasing());
    }
  }

  private IEnumerator Chasing()
  {
    while (gameObject.activeInHierarchy && transform.parent != null && _strategy.CurrentStrategy == EnemyStrategyEnum.Chasing)
    {
      Vector2 targetPosition = new Vector2(Player.Instance.GetPlayerPosition().x, _rb.position.y);
      Vector2 currentPosition = _rb.position;

      Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);
      _rb.MovePosition(newPosition);
      enemyVisual.PositionDifference = _rb.position.x - targetPosition.x;

      yield return null;
    }
  }
}