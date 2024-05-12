using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class radiusChange : MonoBehaviour
{
    public Button btn;
    public Slider slider;

    public Text SliderText;
    public Text RadiusText;

    public float _radius;
        // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(onClick);
        slider.value = GlobalStatus.radius;
        slider.onValueChanged.AddListener(onSliderValueChanged);
        SetSliderValue(slider.value);
        SetRadiusValue(GlobalStatus.radius);
    }

    // Update is called once per frame
    void SetSliderValue(float value)
    {
        SliderText.text = "滑动条值:" + value.ToString("#0.0000");
    }

    void SetRadiusValue(float value)
    {
        RadiusText.text = "当前半径:" + GlobalStatus.radius.ToString("#0.0000");
    }

    void onClick()
    {
        GlobalStatus.radius = _radius;
        SetRadiusValue(_radius);
    }

    void onSliderValueChanged(float value)
    {
        _radius = value;
        SetSliderValue(value);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
