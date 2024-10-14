using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
  [SerializeField] Transform target;
  [SerializeField, Range(0f, 1f)] float parallaxValue = 0.1f;
  [SerializeField] bool disableYAxeParallax;
  Vector3 targetPosition;

  private void Start()
  {
    if (!target)
    {
      target = Camera.main.transform;

      targetPosition = target.position;
    }
  }

  private void Update()
  {
    Vector3 delta = target.position - targetPosition;

    if (disableYAxeParallax)
      delta.y = 0;

    targetPosition = target.position;
    transform.position += delta * parallaxValue;
  }
}