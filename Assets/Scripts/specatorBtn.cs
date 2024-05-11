using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specatorBtn : MonoBehaviour
{
    public Button specatorButton;

    public Text specatorText;
    // Start is called before the first frame update
    void Start()
    {
        specatorButton.onClick.AddListener(onClick);
        SetText(GlobalStatus.isMove);
    }

    private void onClick()
    {
        GlobalStatus.isMove = !GlobalStatus.isMove;
        SetText(GlobalStatus.isMove); 
    }

    void SetText(bool isMove)
    {
        if (GlobalStatus.isMove)
        {
            specatorText.text = "Movable:True";
        }
        else
        {
            specatorText.text = "Movable:False";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
