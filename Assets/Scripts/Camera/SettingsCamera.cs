using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCamera : MonoBehaviour
{
  [SerializeField] private GameObject _player;
  [SerializeField] float offsetCameraY = 8.0f;

  void LateUpdate()
  {
    Vector3 temp = transform.position;
    temp.y = _player.transform.position.y + offsetCameraY;
    temp.x = _player.transform.position.x;

    transform.position = temp;
  }
}
