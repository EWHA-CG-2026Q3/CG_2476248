using UnityEngine;

public class Mid_LanternFloat : MonoBehaviour
{
    public float riseSpeed = 0.3f;   // 1초에 위로 올라가는 거리
    public float spinSpeed = 20f;    // 1초에 도는 각도
    public float swayAmount = 0.2f;  // 좌우로 흔들리는 폭
    public float maxRise = 8f;       // 이만큼 올라가면 처음 위치로 돌아감

    Vector3 startPos;  // 시작 위치 기억
    float risen = 0f;  // 지금까지 올라간 거리

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 1) 위로 이동 (일정 높이에 닿으면 다시 처음부터)
        risen += riseSpeed * Time.deltaTime;
        if (risen > maxRise) risen = 0f;

        // 2) 좌우로 살짝 흔들기 (sin은 -1 ~ 1을 오가는 값)
        float sway = Mathf.Sin(Time.time) * swayAmount;

        // 3) 이동 적용
        transform.position = startPos + new Vector3(sway, risen, 0f);

        // 4) y축 기준 회전 적용
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }
}