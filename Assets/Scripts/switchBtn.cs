using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchBtn : MonoBehaviour
{
    public Button btn;

    public Text switchText;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(onClick);
        SetText(GlobalStatus.isOn);
    }

    private void onClick()
    {
        GlobalStatus.isOn = !GlobalStatus.isOn;
        SetText(GlobalStatus.isOn);
    }

    void SetText(bool isOn)
    {
        if (isOn)
        {
            switchText.text = "Switch:On";
        }
        else
        {
            switchText.text = "Switch:Off";
        }
    }
}
