using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
  [SerializeField] private GameObject startBackground;
  [SerializeField] private GameObject winBackground;
  [SerializeField] private GameObject loseBackground;

  private Background _background = Background.Start;

  public Background Background
  {
    get { return _background; }
    set
    {
      if (_background != value)
      {
        _background = value;
        Debug.Log($"Background changed to: {_background}");
        ChangeBackground();
      }
    }
  }

  public void SetBackground(Background background)
  {
    Background = background;
  }

  private void Start()
  {
    ChangeBackground();
  }

  public void ChangeBackground()
  {
    switch (_background)
    {
      case Background.Win:
        startBackground.SetActive(false);
        winBackground.SetActive(true);
        loseBackground.SetActive(false);
        break;

      case Background.Lose:
        startBackground.SetActive(false);
        winBackground.SetActive(false);
        loseBackground.SetActive(true);
        break;

      case Background.Start:
        startBackground.SetActive(true);
        winBackground.SetActive(false);
        loseBackground.SetActive(false);
        break;
    }
  }
}

public enum Background
{
  Start,
  Win,
  Lose
}