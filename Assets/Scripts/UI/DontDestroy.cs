using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
    foreach (GameObject obj in objs)
    {
      if (obj != this.gameObject && obj.name == this.gameObject.name)
      {
        Destroy(gameObject);
        return;
      }
    }

    DontDestroyOnLoad(gameObject);
  }
}