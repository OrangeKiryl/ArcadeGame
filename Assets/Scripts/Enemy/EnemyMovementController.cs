using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Enemy : MonoBehaviour
{
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private float _speed;
  [SerializeField] private float _minDistance;
  [SerializeField] private float _maxDistance;
  [SerializeField] private float _waitTime;
  private float _startXPosition;
  private float _xPosition;
  //private State _state;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    _startXPosition = transform.position.x;
    _xPosition = _startXPosition + Random.Range(_minDistance, _maxDistance);
    //_state = State.Moving;
  }

  private void Start()
  {
    GetNewXPosition();
  }

  private void FixedUpdate()
  {
    //if (_state == State.Moving)
      StartCoroutine(Movement());
  }

  private IEnumerator Movement()
  {
    if (_rb.position.x == _xPosition || (_rb.position.x > _startXPosition && _rb.position.x > _xPosition) || (_rb.position.x < _xPosition && _rb.position.x < _startXPosition))
    {
      GetNewXPosition();
      yield return new WaitForSeconds(_waitTime);
      if (_rb.position.x < _xPosition)
        _rb.MovePosition(_rb.position + new Vector2(_speed * Time.fixedDeltaTime, 0));
      else
        _rb.MovePosition(_rb.position - new Vector2(_speed * Time.fixedDeltaTime, 0));
    }
    else
    {
      if (_rb.position.x < _xPosition)
        _rb.MovePosition(_rb.position + new Vector2(_speed * Time.fixedDeltaTime, 0));
      else
        _rb.MovePosition(_rb.position - new Vector2(_speed * Time.fixedDeltaTime, 0));
    }
  }

  private void GetNewXPosition()
  {
    //_state = State.Idle;
    //yield return new WaitForSeconds(0);
    if (_startXPosition >_rb.position.x || _xPosition == _startXPosition)
      _xPosition = _startXPosition + Random.Range(_minDistance, _maxDistance);
    else
      _xPosition = _startXPosition - Random.Range(_minDistance, _maxDistance);
    //_state = State.Moving;
  }
}

//enum State
//{
//  Idle,
//  Moving
//}