using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMove : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float xMin = -5.13f;
    public float xMax = 3.54f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 movement = Vector3.zero;
        if (GlobalStatus.isMove)
        {
            movement = new Vector3(-input, 0f, 0f);
        }

        //deltaTime是两帧之间间隔的秒数，*deltaTime是确保每秒移动相同距离
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        Vector3 currentPostion = transform.localPosition;
        currentPostion.x = Mathf.Clamp(currentPostion.x, xMin, xMax);
        transform.localPosition = currentPostion;

    }
}
