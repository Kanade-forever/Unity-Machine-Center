using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMove : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float yMin = 0.5f;
    public float yMax = 1.92f;
    GameObject yMoveObj;
    //private float currentY;
    //private bool isMoveable;
    // Start is called before the first frame update
    void Start()
    {
        yMoveObj = GameObject.Find("YMoveObj");
    }

    // Update is called once per frame
    void Update()
    {
        int y = 0;
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.Q))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.E)) 
        {
            y = -1;
        }
        /*
        if(GlobalStatus.moveMode == GlobalStatus.MoveMode.yMove)
        {
            
        }*/
        if (GlobalStatus.isMove)
        {
            movement = new Vector3(0f, y, 0f);
        }

        //deltaTime是两帧之间间隔的秒数，*deltaTime是确保每秒移动相同距离
        /*
        currentY = yMoveObj.transform.localPosition.y;
        isMoveable = !(Mathf.Abs(currentY - yMax) < 0.1) && !(Mathf.Abs(currentY - yMin) < 0.1);
        if(isMoveable)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }*/

        moveSpeed = GlobalStatus.speed;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        Vector3 currentPostion = transform.localPosition;
        currentPostion.y = Mathf.Clamp(currentPostion.y, yMin, yMax);
        transform.localPosition = currentPostion;
    }
}
