using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class defaultActionSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown defaultActionSelectDropDown;

    public PlayableDirector timeline0;
    public PlayableDirector timeline1;
    public PlayableDirector timeline2;

    public Button radiusChangeBtn;
    
    public Slider radiusSlider;

    private Vector3 currentPosition;
    void Start()
    {
        defaultActionSelectDropDown.onValueChanged.AddListener(onDefaultActionSelectDropDownValueChange);
        timeline0.stopped += Timeline_stopped;
        timeline1.stopped += Timeline_stopped;
        timeline2.stopped += Timeline_stopped;
    }

    private void Timeline_stopped(PlayableDirector obj)
    {
        GlobalStatus.isOn = false;
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
        timeline0.Play();
    }

    private void Action1()
    {
        radiusSlider.value = 0.15f;
        radiusChangeBtn.onClick.Invoke();
        timeline1.Play();
    }

    private void Action2()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
