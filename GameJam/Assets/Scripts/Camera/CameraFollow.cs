using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // 플레이어
    public float smoothSpeed = 5f;
    public Vector3 offset;      // 카메라와 플레이어 거리

    private void LateUpdate()
    {
        if (target == null) return;

        // 플레이어 기준으로 카메라가 가운데 오도록 위치 계산
        Vector3 targetPos = new Vector3(
            target.position.x + offset.x,        // X는 고정 (무한의 계단은 좌우 움직임 없음)
            target.position.y + offset.y,
            transform.position.z
        );

        // 부드럽게 따라가기
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}