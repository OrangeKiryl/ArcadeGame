using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
  public string volumeName;
  public AudioMixer mixer;
  public Slider slider;

  private void Start()
  {
    slider.onValueChanged.AddListener(ChangeVolume);
  }

  private void ChangeVolume(float value)
  {
    mixer.SetFloat(volumeName, value);
  }
}