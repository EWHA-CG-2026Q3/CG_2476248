using UnityEngine;

public class S03_CustomPolygonMesh_Pentagon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-2f, 0f, 0f),  // 0
            new Vector3(0f, 2f, 0f),   // 1
            new Vector3(2f, 0f, 0f),   // 2
            new Vector3(1f, -2f, 0f),  // 3
            new Vector3(-1f, -2f, 0f), // 4
        };

        int[] triangles = new int[] 
        {
             0, 1, 2,
             0, 2, 3,
             0, 3, 4,
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }

    
}
