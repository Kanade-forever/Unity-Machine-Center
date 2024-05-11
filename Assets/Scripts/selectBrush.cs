using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectBrush : MonoBehaviour
{
    public Dropdown dropdown;
    public List<string> listNames = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        AddNames();
        UpdateDropdownView(listNames);
        dropdown.onValueChanged.AddListener(Change);

    }
    //给下拉框绑定事件
    private void Change(int index)
    {
        switch (index){
            case 0:GlobalStatus.currentBrush = GlobalStatus.BrushType.cutter; break;
            case 1:GlobalStatus.currentBrush = GlobalStatus.BrushType.drill; break;
            case 2:GlobalStatus.currentBrush = GlobalStatus.BrushType.borer; break;
        }
    }
    //给下拉框动态添加名字
    private void AddNames()
    {
        string s4 = "cutter";
        string s5 = "drill";
        string s6 = "borer";

        listNames.Add(s4);
        listNames.Add(s5);
        listNames.Add(s6);
    }
    //刷新下拉框显示
    private void UpdateDropdownView(List<string> showNames)
    {
        //清空下下拉框数据
        dropdown.options.Clear();
        Dropdown.OptionData tempData;
        for (int i = 0; i < showNames.Count; i++)
        {
            tempData = new Dropdown.OptionData();
            tempData.text = showNames[i];
            dropdown.options.Add(tempData);
        }
        //把第一条数据显示为默认
        dropdown.captionText.text = showNames[0];
    }

}