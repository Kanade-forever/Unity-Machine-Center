using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brushCutter : MonoBehaviour
{
    public SegmentCube cube;//也可以是别的类
    public float radius = 0.1f;
//    public float moveSpeed = 1f;
    bool isCutting = false;

    public Button radiusChangeBtn;

    void Start()
    {
        radius = GlobalStatus.radius;
        var model = transform.GetChild(0); 
        model.localScale = new Vector3(radius * 2, 1, radius * 2);
        radiusChangeBtn.onClick.AddListener(onRadiusChangeBtnClick);
    }

    void onRadiusChangeBtnClick()
    {
        var model = transform.GetChild(0);
        radius = GlobalStatus.radius;
        model.localScale = new Vector3(radius*2, 1, radius * 2);
//        Debug.Log("GlobalRadius:" + GlobalStatus.radius + "   CurrentRadius:" + radius);
    }

    void Update()
    {
        if (!GlobalStatus.isOn)
        {
            return;
        }
        Debug.DrawRay(transform.position, Vector3.down * 10, Color.blue);
//        MoveCtrl(moveSpeed);
        yCut(transform.position);
    }
    /*
    void MoveCtrl(float speed)
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        int y = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            y = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            y = 1;
        }
        transform.Translate(new Vector3(x, y, z) * speed * Time.deltaTime);
    }*/

    void yCut(Vector3 position)
    {
        var ldx = (int)((position.x - radius) / cube.length * cube.segments); //left - down - x
        var rux = (int)((position.x + radius) / cube.length * cube.segments);
        var ldz = (int)((position.z - radius) / cube.width * cube.segments);
        var ruz = (int)((position.z + radius) / cube.width * cube.segments);
        ldx = ldx - 1 <= 0 ? 0 : ldx - 1;
        rux = rux + 1 >= cube.segments ? cube.segments : rux + 1;
        ldz = ldz - 1 <= 0 ? 0 : ldz - 1;
        ruz = ruz + 1 >= cube.segments ? cube.segments : ruz + 1;
        /*
        Debug.Log(position);
        Debug.Log(cube.transform.position);*/

        for (int i = ldz; i <= ruz; i++)
        {
            for (int j = ldx; j <= rux; j++)
            {
                var index = (cube.segments + 1) * i + j;
                var pos = cube.vertices[index];
                var dis2 = (position.x - pos.x) * (position.x - pos.x) + (position.z - pos.z) * (position.z - pos.z);
                var r2 = radius * radius;
                if (pos.y > transform.position.y && dis2 < r2)
                {
                    cube.vertices[index] = new Vector3(cube.vertices[index].x, transform.position.y < 0 ? 0 : transform.position.y, cube.vertices[index].z);
                    isCutting = true;
                }
            }
        }
        if (isCutting)
        {
            cube.UpdateMesh();
            isCutting = false;
        }
    }
}
