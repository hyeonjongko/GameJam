using UnityEngine;

public class FootholdSpawner : MonoBehaviour
{
    public Transform Player;

    private Vector3 _lastFootholdPos; //마지막으로 생성되는 계단의 위치를 저장

    private int _currentDirection = -1; //현재 계단이 생성되는 방향

    private int _footholdInCurrentDirection = 0; // 현재 방향으로 생성되는 계단의 개수

    private int _footholdBeforeDirectionChange; // 방향을 바꾸기 전에 생성할 계단의 총 개수

    //랜덤으로 생성할 계단의 범위
    private int _footholdMinCount = 1;
    private int _footholdMaxCount = 8;

    //다음 계단과 이전 계단의 거리
    private float _distanceX = 0.85f;
    private float _distanceY = 0.3f;

    //계단의 방향 전환
    private int _change = -1;

    //카운터 초기화
    private int _reset = 0;

    //플레이어가 마지막 계단으로부터 접근하면 계단을 생성하는 거리
    private float _newFootholdDistance = 10.0f;

    //계단이 생성되는 X축의 범위
    private float __footholdMinX = -7.0f;
    private float __footholdMaxX = 7.0f;
    void Start()
    {
        _lastFootholdPos = Vector3.zero;

        _footholdBeforeDirectionChange = Random.Range(_footholdMinCount, _footholdMaxCount);

        //// 게임 시작 시 초기 계단 10개를 미리 생성
        //for (int i = 0; i < 10; i++)
        //{
        //    GenerateNextFoothold();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 마지막 계단으로부터 접근하면
        // 새로운 계단을 생성 (무한 생성 효과)
        if (Player.position.y > _lastFootholdPos.y - _newFootholdDistance)
        {
            GenerateNextFoothold();
        }
    }
    void GenerateNextFoothold()
    {
        Vector3 newPos = _lastFootholdPos; // 새로운 계단 위치를 계산하기 위해 마지막 계단 위치를 복사
        newPos.x += _currentDirection * _distanceX;
        newPos.y += _distanceY;


        // X축 범위 체크: 범우;를 벗어나면 강제로 방향 전환
        if (newPos.x < __footholdMinX || newPos.x > __footholdMaxX)
        {
            // 방향 반전
            _currentDirection *= _change;

            // 위치를 다시 계산 (반대 방향으로)
            newPos.x = _lastFootholdPos.x + _currentDirection * _distanceX;

            // 카운터 및 목표 개수 초기화
            _footholdInCurrentDirection = _reset;
            _footholdBeforeDirectionChange = Random.Range(_footholdMinCount, _footholdMaxCount);
        }

        FootholdFactory footholdFactory = GameObject.Find("FootholdFactory").GetComponent<FootholdFactory>();
        GameObject foothold = footholdFactory.MakeFoothold(newPos);

        if (foothold == null)
        {
            return;
        }
        else
        {
            // 발판에 플레이어 정보 전달 (자동 비활성화를 위해 필요)
            Foothold footholdScript = foothold.GetComponent<Foothold>();
            if (footholdScript != null)
            {
                footholdScript.Player = Player;
            }
        }

        _lastFootholdPos = newPos;

        _footholdInCurrentDirection++;

        if (_footholdInCurrentDirection >= _footholdBeforeDirectionChange)
        {
            _currentDirection *= _change; //방향 전환

            _footholdInCurrentDirection = _reset;

            //다음 방향 전환까지의 계단 개수를 다시 랜덤으로 설정
            _footholdBeforeDirectionChange = Random.Range(_footholdMinCount, _footholdMaxCount);

        }
    }
}
