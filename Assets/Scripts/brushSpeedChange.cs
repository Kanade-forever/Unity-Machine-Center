using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class brushSpeedChange : MonoBehaviour
{
    public Slider slider;
    public Text SpeedText;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(onSliderValueChange);
        slider.value = GlobalStatus.speed;
        SetValue(GlobalStatus.speed);
    }

    void SetValue(float value)
    {
        SpeedText.text = value.ToString();
    }

    private void onSliderValueChange(float value)
    {
        GlobalStatus.speed = value;
        SetValue(value);
        EventSystem.current.SetSelectedGameObject(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
