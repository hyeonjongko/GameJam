using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator _anim;

    Player player;

    private Vector3 _startPos;
    private Vector3 _beforePos;


    [SerializeField] private bool _isTurn = false; //false일 때 왼쪽을 볼 것이다.(-180)

    private Vector3 _playerSeeLeft = new Vector3(0, -180, 0);
    private Vector3 _playerSeeRight = Vector3.zero;

    [Header("이동")]
    private int _moveCount = 0;
    private float _startMoveY = 0.4f;
    private float MoveX = 0.85f;
    private float MoveY = 0.3f;


    [Header("발판 위에 있는지 체크")]
    [SerializeField] private Vector3 _checkOffset = new Vector3(0, -0.4f, 0);
    [SerializeField] private float _checkRadius;
    [SerializeField] private string _groundTag = "Foothold";

    private bool isGrounded;
    void Start()
    {
        _anim = GetComponent<Animator>();
        player = GetComponent<Player>();

        _startPos = transform.position;
        _beforePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTurn();
            Move();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move();
        }
        // MoveCount가 0보다 클 때만 발판 체크
        if (_moveCount > 0)
        {
            CheckGroundByPosition();

            if (!isGrounded)
            {
                Debug.Log("발판 없음! 떨어짐!");
                
            }
        }
    }
    public void PlayerTurn()
    {
        _isTurn = _isTurn == true ? false : true;

        if(_isTurn == true)
        {
            //(0,0,0)으로
            gameObject.transform.rotation = Quaternion.Euler(_playerSeeRight);
        }
        else
        {
            //(0,-180,0)으로
            gameObject.transform.rotation = Quaternion.Euler(_playerSeeLeft);
        }
    }
    public void Move()
    {
        if (_isTurn == true)
        {
            _beforePos += new Vector3(MoveX, MoveY, 0);
        }
        else
        {
            _beforePos += new Vector3(-MoveX, MoveY, 0);
        }

        if(_moveCount == 0)
        {
            _beforePos.y += _startMoveY;
        }

        transform.position = _beforePos;
        _moveCount++;

        //Player.CheckFoothold();
    }
    void CheckGroundByPosition()
    {
        // 플레이어 위치에서 오프셋만큼 떨어진 위치 계산
        Vector2 checkPosition = (Vector2)transform.position + new Vector2(_checkOffset.x, _checkOffset.y);

        // 2D용 OverlapCircleAll로 해당 위치의 모든 물체 가져오기
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, _checkRadius);

        // Tag가 일치하는 물체가 있는지 확인
        isGrounded = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(_groundTag))
            {
                Debug.Log($"감지된 발판: {collider.gameObject.name}");
                isGrounded = true;
                break;
            }
        }

        // 디버그용 선 그리기 (Scene 뷰에서 확인 가능)
        Debug.DrawLine(transform.position, checkPosition, isGrounded ? Color.green : Color.red);
    }
    // Scene 뷰에서 체크 범위 시각화 (2D용)
    void OnDrawGizmos()
    {
        if (_moveCount > 0) // MoveCount가 0보다 클 때만 그리기
        {
            Vector2 checkPosition = (Vector2)transform.position + new Vector2(_checkOffset.x, _checkOffset.y);
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(checkPosition, _checkRadius);
        }
    }

    //// 다른 스크립트에서 사용할 수 있는 public 메서드
    //public bool IsGrounded()
    //{
    //    return isGrounded;
    //}
}
