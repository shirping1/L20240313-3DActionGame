using Unity.VisualScripting;
using UnityEngine;

public class TouchPad : MonoBehaviour
{
    //UI에서 사용하는 트랜스폼
    private RectTransform _touchPad;

    // 터치 입력 중에 방향 컨트롤러의 영역 안에 있는 입력을구분하기 위한 Id
    private int _touchId = -1;

    // 입력이 시작되는 좌표
    private Vector3 _startPos = Vector3.zero;

    // 방향 컨트롤러가 원으로 움직이는 반지름
    private float _dragRadius = 0.0f;

    //플레이어의 움직임을 관리하는 PlayerMovement와 연결해 방향키 신호를 보내는 역할
    public PlayerMovement _player;

    private bool _buttonPressed = false;

    private void Start()
    {
        _touchPad = GetComponent<RectTransform>();

        _startPos = _touchPad.position;

        _dragRadius = 60.0f;
    }

    public void ButtonDown()
    {
        _buttonPressed = true;
    }

    public void ButtonUp()
    {
        _buttonPressed = false;
    }

    private void FixedUpdate()
    {
        HandleTouchInput();

        // #if는 조건부 컴파일을 구현하기 위한 전처리기
        // 유니티 에디터 / 웹 / 인게임에서 마우스 클릭으로 작업
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBGL
        HandleInput(Input.mousePosition);
#endif
    }

    void HandleTouchInput()
    {
        int i = 0; // 터치 아이디를 매기기 위한 변수

        // 터치가 1번이라도 들어오면 실행
        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                i++;

                // 입력한 터치 값으로 좌표를 계산
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);

                // 터치 입력이 방금 시작되었다면
                if(touch.phase == TouchPhase.Began)
                {

                    // 그 터치가 현재의 방향키 범위 내에 존재하는 경우
                    if(touch.position.x <= (_startPos.x + _dragRadius))
                    {
                        _touchId = i;
                    }
                }

                // 터치 입력이 움직였거나 가만히 있는 상황일 경우
                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    // 터치 아이디로 지정이 된 상태일때
                    if(_touchId == i)
                    {
                        HandleInput(touchPos);
                    }
                }

                // 터치 입력이 끝난경우
                if(touch.phase == TouchPhase.Ended)
                {
                    // 아이디 해제
                    if(_touchId == i)
                    {
                        _touchId = -1;
                    }
                }
            }
        }
    }

    void HandleInput(Vector3 input)
    {
        // 버튼이 눌러져있는 상황일 경우
        if(_buttonPressed)
        {
            // 방향 컨트롤러의 기준 좌표부터 입력받은 좌표가 얼마나 떨어져있는지
            Vector3 diffVector = (input - _startPos);

            // sqrMagnitude 는 두 점 간의 거리의 제곱에 루트를 한값
            // Vector3.Distance 와 비슷 
            // 정확한 거리를 체크하는게 아닌 값의 크고 작은 지만 판단하는 식
            if(diffVector.sqrMagnitude > _dragRadius * _dragRadius)
            {
                diffVector.Normalize(); // 방향 벡터의 거리를 1로 설정

                // 방향 컨트롤러는 최대치만큼 이동
                _touchPad.position = _startPos + diffVector * _dragRadius;
            }
            else
            {
                _touchPad.position = input;
            }
        }
        // 버튼을 누르지 않는 경우
        else
        {
            // 버튼에서 손이 떼어질 경우, 방향키를 원래 위치로 이동
            _touchPad.position = _startPos;

        }

        // 방햘키와 기준점의 차이를 계산
        Vector3 diff = _touchPad.position - _startPos;

        // 거리만 나누어 방향을 계산
        Vector2 normDiff = new Vector3(diff.x / _dragRadius, diff.y / _dragRadius);

        //플레이어 연결여부 체크
        if(_player != null)
        {
            // 플레이어에게 변경된 좌표를 전달
            _player.OnStickChanged(normDiff);
        }
    }
}

