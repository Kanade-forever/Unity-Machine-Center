using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMove : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float zMin = -30.06f;
    public float zMax = -20.27f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        if (GlobalStatus.isMove)
        {
            movement = new Vector3(0f, 0f, -input);
        }


        moveSpeed = GlobalStatus.speed;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        Vector3 currentPostion = transform.localPosition;
        currentPostion.z = Mathf.Clamp(currentPostion.z, zMin, zMax);
        transform.localPosition = currentPostion;
    }
}
