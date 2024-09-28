using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Player : MonoBehaviour
{
  public static Player Instance { get; private set; }
  [SerializeField] private float _speed = 200f;
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private BoxCollider2D _collider;
  [SerializeField] private float _jumpForce = 300f;
  private bool _isRunning = false;
  //private bool _onTheStairs = false;
  private bool _isGrounded = false;
  private float _groundCheckDistance = 0.1f;
  private Vector2 _direction;

  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    GameInputs.jump.AddListener(OnJumping);
  }

  private void Update()
  {
    CheckIsGrounded();
  }

  private void FixedUpdate()
  {
    Movement();
  }

  private void Movement()
  {
    _direction = transform.right * GameInputs.Instance.GetMoveVector();
    transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + _direction, _speed * Time.fixedDeltaTime);

    if (_direction.x != 0)
      _isRunning = true;
    else
      _isRunning = false;
  }

  public Vector2 GetMoveDirection()
  {
    return _direction;
  }

  public Vector2 GetPlayerPosition()
  {
    return transform.position;
  }

  public bool IsRunning()
  {
    return _isRunning;
  }

  public bool IsGrounded()
  {
    return _isGrounded;
  }

  private void OnJumping()
  {
    if (_isGrounded)
      _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
  }

  private void CheckIsGrounded()
  {
    if (_collider != null)
    {
      Vector2 pointLeft = new Vector2(transform.position.x - _collider.size.x / 2, transform.position.y);
      Vector2 pointRight = new Vector2(transform.position.x + _collider.size.x / 2, transform.position.y);

      RaycastHit2D hitLeft = Physics2D.Raycast(pointLeft, Vector2.down, _groundCheckDistance);
      RaycastHit2D hitRight = Physics2D.Raycast(pointRight, Vector2.down, _groundCheckDistance);

      if ((hitLeft.collider != null && hitLeft.collider.gameObject.CompareTag("Ground")) ||
          (hitRight.collider != null && hitRight.collider.gameObject.CompareTag("Ground")))
      {
        _isGrounded = true;
        return;
      }
      _isGrounded = false;
    }
    else
    {
      Debug.Log("Collider is null");
    }
  }
}