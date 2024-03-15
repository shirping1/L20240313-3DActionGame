using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 알림창에서 사용할 데이터
public class DialogDataAlert : DialogData
{
    public string Title { get; private set; }

    public string Message { get; private set; }

    // 유니티에서 사용할 수있는 delegate Action
    // 유저가 확인 버튼 눌렀을 때 호출되는 콜백 함수를 저장하겠습니다.
    // 콜백 함수
    public Action Callback { get; private set; }

    public DialogDataAlert(string title, string message, Action callback = null) : base(DialogType.Alert)
    {
        Title = title;
        Message = message;
        Callback = callback;
    }


}
