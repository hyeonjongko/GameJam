using UnityEngine;

public class GroundFollow : MonoBehaviour
{
    public GameObject Ground; // Ground 오브젝트를 Inspector에서 할당

    public Transform MainCamera; // 카메라를 Inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCamera = Camera.main.transform; // 메인 카메라를 자동으로 할당
    }

    // Update is called once per frame
    void Update()
    {
        Ground.transform.position = new Vector3(MainCamera.position.x, transform.position.y, transform.position.z); // 카메라의 X 위치를 따라가도록 설정
    }
}
