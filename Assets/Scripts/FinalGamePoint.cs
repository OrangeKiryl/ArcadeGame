using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalGamePoint : MonoBehaviour
{
  [SerializeField] private Collider2D _zone;
  [SerializeField] private bool _isWin;
  public static UnityEvent<bool> finalGame = new();

  private void OnTriggerEnter2D(Collider2D collision)
  {
    finalGame.Invoke(_isWin);
  }
}