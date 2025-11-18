using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator _anim;

    private Vector3 _startPos;
    private Vector3 _beforePos;


    [SerializeField] private bool _isTurn = false; //false일 때 왼쪽을 볼 것이다.(-180)

    private Vector3 _playerSeeLeft = new Vector3(0, -180, 0);
    private Vector3 _playerSeeRight = Vector3.zero;

    private int _moveCount = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _startPos = transform.position;
        _beforePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTurn();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move();
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
            _beforePos += new Vector3(0.85f, 0.3f, 0);
        }
        else
        {
            _beforePos += new Vector3(-0.85f, 0.3f, 0);
        }

        if(_moveCount == 0)
        {
            _beforePos.y += 0.4f;
        }

        transform.position = _beforePos;
        _moveCount++;
    }
}
