using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public GameObject[] Backgrounds; // 배경 3개를 Inspector에서 할당
    public Transform Player; // 플레이어를 Inspector에서 할당
    public float BackgroundHeight; // 배경 하나의 높이

    void Start()
    {
        // 배경 높이를 자동으로 계산 (배경에 SpriteRenderer가 있는 경우)
        if (BackgroundHeight == 0 && Backgrounds.Length > 0)
        {
            SpriteRenderer sr = Backgrounds[0].GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                BackgroundHeight = sr.bounds.size.y;
            }
        }
    }

    void Update()
    {
        // 각 배경이 플레이어보다 충분히 아래에 있는지 체크
        foreach (GameObject bg in Backgrounds)
        {
            // 플레이어가 배경보다 충분히 위로 올라갔으면
            if (Player.position.y > bg.transform.position.y + BackgroundHeight)
            {
                // 가장 위에 있는 배경 찾기
                float maxY = float.MinValue;
                foreach (GameObject otherBg in Backgrounds)
                {
                    if (otherBg.transform.position.y > maxY)
                    {
                        maxY = otherBg.transform.position.y;
                    }
                }

                // 가장 위 배경 바로 위에 재배치
                bg.transform.position = new Vector3(bg.transform.position.x, maxY + BackgroundHeight, bg.transform.position.z);
            }
        }
    }
}