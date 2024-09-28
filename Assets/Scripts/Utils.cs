using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
  public static Utils Instance { get; private set; }

  [SerializeField] public static readonly float _gravity = -10f;

  private void Awake()
  {
    Instance = this;
  }
}