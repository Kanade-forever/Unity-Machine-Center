using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushRotate : MonoBehaviour
{
    public float rotateSpeed = 1000.0f;
    public Vector3 rotateDirection = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalStatus.isOn)
        {
            return;
        }
        transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }
}
