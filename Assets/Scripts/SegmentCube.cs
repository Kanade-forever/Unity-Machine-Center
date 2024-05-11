using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SegmentCube : MonoBehaviour
{
    MeshFilter mf;
    [HideInInspector] public int[] triangels;
    [HideInInspector] public Vector3[] vertices;
    public int segments = 100;
    public float height = 0.8f;
    public float width = 0.8f;
    public float length = 0.8f;

    void Start()
    {
        mf = GetComponent<MeshFilter>();
        mf.mesh = SegmentedCubeCreate();
    }

    public Mesh SegmentedCubeCreate()
    {
        Mesh mesh = new Mesh();
        mesh.name = "testCube";
        //扩大mesh包含顶点的数量
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        //创建vertices
        vertices = new Vector3[(segments + 1) * (segments + 1) + (segments + 1) * 4];
        for (int i = 0; i <= segments; i++)    
        {
            for (int j = 0; j <= segments; j++)
            {
                var len = (float)i / segments * length;
                var wid = (float)j / segments * width;
                vertices[(segments + 1) * i + j] = new Vector3(wid, height, len);
            }
        }
        //底部
        var initIndex = (segments + 1) * (segments + 1);//底部点的起始索引
        for (int i = 0; i <= segments; i++)
        {
            vertices[initIndex + (segments + 1) * 0 + i] = new Vector3((float)i / segments * width, 0, 0);
            vertices[initIndex + (segments + 1) * 1 + i] = new Vector3(width, 0, (float)i / segments * length);
            vertices[initIndex + (segments + 1) * 2 + i] = new Vector3((float)(segments - i) / segments * width, 0, length);
            vertices[initIndex + (segments + 1) * 3 + i] = new Vector3(0, 0, (float)(segments - i) / segments * length);
        }

        //创建triangles
        int index = 0;
        triangels = new int[segments * segments * 6 + 4 * segments * 6 + 6];
        for (int i = 0; i < segments; i++)
        {
            for (int j = 0; j < segments; j++)
            {
                var current = (segments + 1) * i + j;
                var next = current + segments + 1;
                triangels[index++] = next;
                triangels[index++] = next + 1;
                triangels[index++] = current;
                triangels[index++] = current;
                triangels[index++] = next + 1;
                triangels[index++] = current + 1;
            }
        }
        //侧面
        for (int i = 0; i < segments; i++)
        {
            triangels[index++] = i;
            triangels[index++] = i + initIndex + 1;
            triangels[index++] = i + initIndex;
            triangels[index++] = i;
            triangels[index++] = i + 1;
            triangels[index++] = i + initIndex + 1;
        }
        for (int i = 0; i < segments; i++)
        {
            triangels[index++] = (i + 1) * (segments + 1) - 1;
            triangels[index++] = i + initIndex + (segments + 1) + 1;
            triangels[index++] = i + initIndex + (segments + 1);
            triangels[index++] = (i + 1) * (segments + 1) - 1;
            triangels[index++] = (i + 2) * (segments + 1) - 1;
            triangels[index++] = i + initIndex + (segments + 1) + 1;
        }
        for (int i = 0; i < segments; i++)
        {
            triangels[index++] = initIndex - i - 1;
            triangels[index++] = i + initIndex + (segments + 1) * 2 + 1;
            triangels[index++] = i + initIndex + (segments + 1) * 2;
            triangels[index++] = initIndex - i - 1;
            triangels[index++] = initIndex - i - 2;
            triangels[index++] = i + initIndex + (segments + 1) * 2 + 1;
        }
        for (int i = 0; i < segments; i++)
        {
            triangels[index++] = (segments - i) * (segments + 1);
            triangels[index++] = i + initIndex + (segments + 1) * 3 + 1;
            triangels[index++] = i + initIndex + (segments + 1) * 3;
            triangels[index++] = (segments - i) * (segments + 1);
            triangels[index++] = (segments - i - 1) * (segments + 1);
            triangels[index++] = i + initIndex + (segments + 1) * 3 + 1;
        }
        //底部
        triangels[index++] = initIndex;
        triangels[index++] = initIndex + (segments + 1);
        triangels[index++] = initIndex + (segments + 1) * 2;
        triangels[index++] = initIndex + (segments + 1) * 3;
        triangels[index++] = initIndex;
        triangels[index++] = initIndex + (segments + 1) * 2;

        mesh.vertices = vertices;
        mesh.triangles = triangels;
        mesh.RecalculateNormals();
        return mesh;
    }

    public void UpdateMesh()
    {
        mf.mesh.vertices = vertices;
        mf.mesh.triangles = triangels;
        mf.mesh.RecalculateNormals();
    }
}
