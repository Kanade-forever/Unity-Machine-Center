using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatus : MonoBehaviour
{
    //public static MoveMode moveMode = MoveMode.unMove;
    public static CameraAvailable currentCamera = CameraAvailable.XFixedCamera;
    public static BrushType currentBrush = BrushType.cutter;

    public static bool isOn = false;
    public static bool isMove = false;
    public static bool isFrozeCamera = false;

    public static int cutterFlash = 0;
    public const int cutterFlashPerSec = 160;

    public static float radius = 0.03f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public enum MoveMode
    {
        yMove,
        xMove,
        zMove,
        unMove
    }*/

    public enum CameraAvailable
    {
        XFixedCamera,
        YFixedCamera,
        ZFixedCamera,
        FreeCamera
    }

    public enum BrushType
    {
        cutter,
        drill,
        borer
    }
}
