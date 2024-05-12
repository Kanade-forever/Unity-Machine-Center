using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectCamera : MonoBehaviour
{
    public Dropdown dropdown;
    //public List<string> listNames = new List<string>();

    public Camera xFixedCamera;
    public Camera yFixedCamera;
    public Camera zFixedCamera;
    public Camera FreeCamera;

    public Button frozeFreeCameraBtn;

    public Text FrozeCameraText;
    // Start is called before the first frame update
    void Start()
    {
        xFixedCamera.gameObject.SetActive(true);
        yFixedCamera.gameObject.SetActive(false);
        zFixedCamera.gameObject.SetActive(false);
        FreeCamera.gameObject.SetActive(false);
        frozeFreeCameraBtn.gameObject.SetActive(false);
        FrozeCameraText.gameObject.SetActive(false);
        /*
        AddNames();
        UpdateDropdownView(listNames);*/
        dropdown.onValueChanged.AddListener(Change);

    }
    //����������¼�
    private void Change(int index)
    {
        switch (index)
        {
            case 0: GlobalStatus.currentCamera = GlobalStatus.CameraAvailable.XFixedCamera; break;
            case 1: GlobalStatus.currentCamera = GlobalStatus.CameraAvailable.YFixedCamera; break;
            case 2: GlobalStatus.currentCamera = GlobalStatus.CameraAvailable.ZFixedCamera; break;
            case 3: GlobalStatus.currentCamera = GlobalStatus.CameraAvailable.FreeCamera; break;
        }
        SwitchCamera();

    }

    public void SwitchCamera()
    {
        // �л�������ļ���״̬
        xFixedCamera.gameObject.SetActive(false);
        yFixedCamera.gameObject.SetActive(false);
        zFixedCamera.gameObject.SetActive(false);
        FreeCamera.gameObject.SetActive(false);
        frozeFreeCameraBtn.gameObject.SetActive(false);
        FrozeCameraText.gameObject.SetActive(false);

        switch (GlobalStatus.currentCamera)
        {
            case GlobalStatus.CameraAvailable.XFixedCamera: xFixedCamera.gameObject.SetActive(true); break;
            case GlobalStatus.CameraAvailable.YFixedCamera: yFixedCamera.gameObject.SetActive(true); break;
            case GlobalStatus.CameraAvailable.ZFixedCamera: zFixedCamera.gameObject.SetActive(true); break;
            case GlobalStatus.CameraAvailable.FreeCamera:
                {
                    frozeFreeCameraBtn.gameObject.SetActive(true);
                    FrozeCameraText.gameObject.SetActive(true);
                    FreeCamera.gameObject.SetActive(true); break;
                }
        }
    }
    /*
    //��������̬�������
    private void AddNames()
    {
        string s4 = "XFixedCamera";
        string s5 = "YFixedCamera";
        string s6 = "ZFixedCamera";
        string s7 = "FreeCamera";

        listNames.Add(s4);
        listNames.Add(s5);
        listNames.Add(s6);
        listNames.Add(s7);
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
    }*/

}