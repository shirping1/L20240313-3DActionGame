using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Delegate?
// C/C++ 의 함수 포인터와 비슷한 개념

// Delegate로 함수 타입에 대한 정의 를 진행하고
// 매개변수에 대한 설계를 진행할 경우
// 같은 타입, 같은 매개변수를 가진 메소드를 불러서 사용할 수 있는 도구 (대리자)

public class DelegateExample : MonoBehaviour
{
    // 1. Delegate 선언
    delegate void DelegateTester();

    // 2. delegate로 선언한 형태와 동일한 함수를 구현
    void DelegateTester01()
    {
        Debug.Log("대리자 테스트 1");
    }

    void DelegateTester02()
    {
        Debug.Log("대리자 테스트 2");
    }

    // Start is called before the first frame update
    void Start()
    {
        //delegate 생성 -> delegate명 변수명 = new delegate명(함수명);
        DelegateTester delegateTester = new DelegateTester(DelegateTester01);

        // delegate 호출
        delegateTester();

        delegateTester = DelegateTester02; // delegate로 처리할 함수 변경

        delegateTester();
    }
}
