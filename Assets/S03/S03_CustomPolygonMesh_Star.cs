using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class S03_CustomPolygonMesh_Star : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),    // 0 중심점
            new Vector3(0f, 4f, 0f),    // 1 바깥
            new Vector3(1f, 1f, 0f),    // 2 안쪽
            new Vector3(4f, 1f, 0f),    // 3 바깥
            new Vector3(2f, -1f, 0f),   // 4 안쪽
            new Vector3(3f, -4f, 0f),   // 5 바깥
            new Vector3(0f, -2f, 0f),   // 6 안쪽
            new Vector3(-3f, -4f, 0f),  // 7 바깥
            new Vector3(-2f, -1f, 0f),  // 8 안쪽
            new Vector3(-4f, 1f, 0f),   // 9 바깥
            new Vector3(-1f, 1f, 0f),   // 10 안쪽
        };
    }

    
}
