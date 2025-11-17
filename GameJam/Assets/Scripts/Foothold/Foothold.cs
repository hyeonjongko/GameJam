using UnityEngine;

public class Foothold : MonoBehaviour
{
    public Transform player;

    private float _deleteDistance = 11.0f;
    // Update is called once per frame
    void Update()
    {
        // 플레이어가 설정되지 않았으면 실행하지 않음
        if (player == null)
            return;

        // 이 발판이 플레이어보다 30유닛 아래로 내려가면 비활성화
        // 비활성화된 오브젝트는 풀로 돌아가서 재사용 가능
        if (transform.position.y < player.position.y - _deleteDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
