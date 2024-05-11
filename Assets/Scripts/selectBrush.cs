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
    //����������¼�
    private void Change(int index)
    {
        switch (index){
            case 0:GlobalStatus.currentBrush = GlobalStatus.BrushType.cutter; break;
            case 1:GlobalStatus.currentBrush = GlobalStatus.BrushType.drill; break;
            case 2:GlobalStatus.currentBrush = GlobalStatus.BrushType.borer; break;
        }
    }
    //��������̬�������
    private void AddNames()
    {
        string s4 = "cutter";
        string s5 = "drill";
        string s6 = "borer";

        listNames.Add(s4);
        listNames.Add(s5);
        listNames.Add(s6);
    }
    //ˢ����������ʾ
    private void UpdateDropdownView(List<string> showNames)
    {
        //���������������
        dropdown.options.Clear();
        Dropdown.OptionData tempData;
        for (int i = 0; i < showNames.Count; i++)
        {
            tempData = new Dropdown.OptionData();
            tempData.text = showNames[i];
            dropdown.options.Add(tempData);
        }
        //�ѵ�һ��������ʾΪĬ��
        dropdown.captionText.text = showNames[0];
    }

}