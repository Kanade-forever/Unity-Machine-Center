using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frozeCameraBtn : MonoBehaviour
{
    public Button btn;

    public Text FrozeCameraText;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(onClick);
        SetText(GlobalStatus.isFrozeCamera);
    }

    void SetText(bool isFroze)
    {
        if(isFroze)
        {
            FrozeCameraText.text = "CameraFrozen";
        }
        else
        {
            FrozeCameraText.text = "CameraFree";
        }
    }

    private void onClick()
    {
        GlobalStatus.isFrozeCamera = !GlobalStatus.isFrozeCamera;
        SetText(GlobalStatus.isFrozeCamera);
    }
}
