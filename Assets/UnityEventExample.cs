using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// event(이벤트) : 개체에서 작업 살행을 알리기 위해 보내는 메세지
// 이벤트는 외부 가입자(subscriber)에게 특정 일으 알려주는 기능을 가집니다.

// Event Handler(이벤트 핸들러) : 구독자가 이벤트가 발생할 경우 어떤 명령을 실행할 지 지정해주는 것 
// +=을 통해 이벤트에 대한  추가가 가능, -=를 통해 이벤트를 제거하는 것도 가능
// 이벤트 발생 시 추가된 핸들러는 순차적으로 호출

class ClickEvent
{
    public event EventHandler Click;

    public void MouseButtonDown()
    {
        if(Click != null)
        {
            Click(this, EventArgs.Empty);
            // EventArgs 이벤트 받을 때 파라미터로 데이터를 받고 싶은 경우 해당 클래스를 상속받아 사용
            // EventArgs는 이벤트 발생과 관련된 정보를 가지고 있음
            // 이벤트 핸들러가 사용하는 파라미터 값임
        }
    }
}



public class UnityEventExample : MonoBehaviour
{
    ClickEvent clickEvent;
    DailyCheck dailyCheck;
    public Text eventText;
    string dialog;
    // Start is called before the first frame update
    void Start()
    {
        clickEvent = new ClickEvent();
        clickEvent.Click += new EventHandler(ButtonClick);
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        Debug.Log("버튼을 클릭했습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            clickEvent.MouseButtonDown();
        }
    }
}
