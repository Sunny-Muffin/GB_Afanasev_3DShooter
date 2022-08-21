using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        AudioListener.volume = slider.value;
        slider.onValueChanged.AddListener(value => AudioListener.volume = value);
    }
}
