using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class defaultActionSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown defaultActionSelectDropDown;

    public PlayableDirector timeline;

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
            case 0: Action0(); break;
            case 1: Action1(); break;
            case 2: Action2(); break;
        }
    }

    private void Action0()
    {
        Debug.Log("Action0 played");
        timeline.Play();
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
