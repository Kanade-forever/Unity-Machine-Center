using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetCubeBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;

    public SegmentCube cube;
    void Start()
    {
        btn.onClick.AddListener(onClick);
    }

    void onClick()
    {
        cube.GetComponent<MeshFilter>().mesh = cube.SegmentedCubeCreate();
    }

    // Update is called once per frame
}
