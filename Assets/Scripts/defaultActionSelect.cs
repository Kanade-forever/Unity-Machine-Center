using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defaultActionSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown defaultActionSelectDropDown;

    public GameObject brush;

    private bool isAction0 = false;
    private bool isAction1 = false;
    private bool isAction2 = false;

    private Vector3 currentPosition;
    void Start()
    {
        defaultActionSelectDropDown.onValueChanged.AddListener(onDefaultActionSelectDropDownValueChange);
    }

    void onDefaultActionSelectDropDownValueChange(int index)
    {
        GlobalStatus.isOn = true;
        GlobalStatus.isMove = false;
        GlobalStatus.isFrozeCamera = true;
        switch (index)
        {
            case 0: isAction0 = true; break;
            case 1: isAction1 = true; break;
            case 2: isAction2 = true; break;
        }
    }

    private void Action0()
    {

    }

    private void Action1()
    {

    }

    private void Action2()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
