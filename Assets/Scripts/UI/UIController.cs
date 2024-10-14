using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
  [SerializeField] private Button _play;
  [SerializeField] private Button _exit;
  [SerializeField] private Button _options;
  [SerializeField] private Button _closeOptions;
  [SerializeField] private GameObject _optionsMenu;
  [SerializeField] private GameObject _buttonsPanel;
  [SerializeField] private AudioSource _openCloseMenuSound;
  [SerializeField] private AudioSource _clickButton;
  [SerializeField] private AudioSource _soundGame;
  [SerializeField] private AudioSource _soundMenu;
  [SerializeField] internal Canvas _canvas;

  private void Start()
  {
    _play.onClick.AddListener(OnPlayButtonClicked);
    _exit.onClick.AddListener(OnExitButtonClicked);
    _options.onClick.AddListener(() => OpenCloseOptions(true));
    _closeOptions.onClick.AddListener(() => OpenCloseOptions(false));
  }

  public Canvas Canvas => _canvas;

  private void OnExitButtonClicked()
  {
    Application.Quit();
  }

  private void OpenCloseOptions(bool open)
  {
    _optionsMenu.SetActive(open);
    _buttonsPanel.SetActive(!open);
    _openCloseMenuSound.Play();
  }

  private void OnPlayButtonClicked()
  {
    _clickButton.Play();
    _canvas.gameObject.SetActive(false);
    SceneManager.LoadSceneAsync(1);
    _soundMenu.Stop();
    _soundGame.Play();
  }
}