using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
  public static Utils Instance { get; private set; }

  public static readonly float _gravity = -10f;

  private void Awake()
  {
    Instance = this;
  }

  private void Start()
  {
    FinalGamePoint.finalGame.AddListener(FinalGame);
  }

  private void FinalGame(bool isWin)
  {
    GameObject controller = GameObject.Find("UIController");
    if (controller != null)
    {
      UIController uiController = controller.GetComponent<UIController>();
      if (uiController != null)
      {
        Canvas canvas = uiController._canvas;
        if (canvas != null)
        {
          canvas.GetComponent<BackgroundLoader>().SetBackground(isWin ? Background.Win : Background.Lose);
        }
      }
    }
    SceneManager.LoadSceneAsync(0);
  }
}