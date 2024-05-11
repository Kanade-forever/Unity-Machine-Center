using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchBrush : MonoBehaviour
{
    public GameObject drill;
    public GameObject cutter;
    public GameObject borer;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        cutter.SetActive(true);
        drill.SetActive(false);
        borer.SetActive(false);
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onClick()
    {
        drill.SetActive(false);
        cutter.SetActive(false);
        borer.SetActive(false);
        switch(GlobalStatus.currentBrush)
        {
            case GlobalStatus.BrushType.drill:drill.SetActive(true); break;
            case GlobalStatus.BrushType.cutter: cutter.SetActive(true); break;
            case GlobalStatus.BrushType.borer: borer.SetActive(true); break;
        }
    }
}
