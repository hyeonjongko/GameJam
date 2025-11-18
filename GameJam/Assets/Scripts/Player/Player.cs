using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void CheckFoothold()
    //{
    //    Vector3 checkPosition = transform.position - new Vector3(0, 0.4f, 0);

    //    // Raycast로 발판 체크 (짧은 거리만 체크)
    //    RaycastHit hit;
    //    //Physics.Raycast(시작점, 방향, 맞은 물체의 정보, 거리)
    //    if (Physics.Raycast(checkPosition, Vector3.down, out hit, 0.1f))
    //    {
    //        // 발판이 있고, 그것이 "Foothold" 태그를 가지고 있다면
    //        if (hit.collider.CompareTag("Foothold"))
    //        {
    //            Debug.Log("발판 있음!");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("발판 없음! 떨어집니다!");
    //    }
    //}
}
