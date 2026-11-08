using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mid_LanternMesh : MonoBehaviour
{
    public int n = 12;              // 몇 각형인지
    public float bottomRadius = 0.35f; // 아래 원 반지름 (좁음)
    public float topRadius = 0.5f;     // 위 원 반지름 (넓음)
    public float height = 1f;          // 풍등 높이

    void Start()
    {
        // ---------- 정점 ----------
        Vector3[] vertices = new Vector3[2 * n + 2];
        Vector2[] uvs = new Vector2[2 * n + 2];

        for (int i = 0; i < n; i++)
        {
            float angle = 360f / n * i * Mathf.Deg2Rad; // 각도 → 라디안
            float c = Mathf.Cos(angle);
            float s = Mathf.Sin(angle);

            vertices[i] = new Vector3(c * bottomRadius, 0f, s * bottomRadius); // 아래 원
            vertices[n + i] = new Vector3(c * topRadius, height, s * topRadius);    // 위 원
            uvs[i] = new Vector2((float)i / n, 0f);
            uvs[n + i] = new Vector2((float)i / n, 1f);
        }

        int topCenter = 2 * n;       // 위 뚜껑 가운데 점 번호
        int bottomCenter = 2 * n + 1; // 아래 뚜껑 가운데 점 번호
        vertices[topCenter] = new Vector3(0f, height, 0f);
        vertices[bottomCenter] = new Vector3(0f, 0f, 0f);
        uvs[topCenter] = new Vector2(0.5f, 1f);
        uvs[bottomCenter] = new Vector2(0.5f, 0f);

        // ---------- 삼각형 ----------
        // 옆면 n개 × 삼각형 2개 + 위 뚜껑 n개 + 아래 뚜껑 n개 = 4n개, 각 3개 인덱스
        int[] triangles = new int[4 * n * 3];
        int t = 0; // triangles 배열에 다음으로 채울 위치

        for (int i = 0; i < n; i++)
        {
            int next = (i + 1) % n; // 마지막 점 다음은 0번으로

            int b0 = i;         // 아래 원 i번
            int b1 = next;      // 아래 원 다음 점
            int t0 = n + i;     // 위 원 i번
            int t1 = n + next;  // 위 원 다음 점

            // 옆면 사각형 = 삼각형 2개 (바깥에서 볼 때 시계 방향)
            triangles[t++] = t0; triangles[t++] = t1; triangles[t++] = b1;
            triangles[t++] = t0; triangles[t++] = b1; triangles[t++] = b0;

            // 위 뚜껑 (위에서 볼 때 시계 방향)
            triangles[t++] = topCenter; triangles[t++] = t1; triangles[t++] = t0;

            // 아래 뚜껑 (아래에서 볼 때 시계 방향)
            triangles[t++] = bottomCenter; triangles[t++] = b0; triangles[t++] = b1;
        }

        // ---------- 메시 적용 (S03과 같은 방식) ----------
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}