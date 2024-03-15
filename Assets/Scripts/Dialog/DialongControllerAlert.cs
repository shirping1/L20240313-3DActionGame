using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 알림창
public class DialongControllerAlert : DialogController
{
    // 제목
    public Text LabelTitle;

    // 내용
    public Text labelMessage;
    

    // 클래스에서 전달할 알림창의 데이터를 객체 선언
    DialogDataAlert Data { get; set; }

    public void OnClickOk()
    {
        if(Data != null && Data.Callback != null)
        {
            Data.Callback();
        }
        // 작업이 끝난 후 현재의 팝업 창을 관리자에서 제거
        DialogManager.Instance.Pop();
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        // 데이터가 알람이 아닐 경우
        if(!(data is DialogDataAlert))
        {
            // 에러 메시지 출력
            Debug.LogError("Invaild dialog data!");
            return; // 작업 종료
        }
        // 데이터를 안내 데이터로써 받아오겠습니다.
        Data = data as DialogDataAlert;
        // 텍스트 값에 데이터의 속성을 적용합니다.
        LabelTitle.text = Data.Title;
        labelMessage.text = Data.Message;
    }

    public override void Update()
    {
        base.Update();
        // 인스턴스를 통해 Alert 타입의 컨트롤러를 다루고 있음을 등록
        DialogManager.Instance.Regist(DialogType.Alert, this);
    }
}
