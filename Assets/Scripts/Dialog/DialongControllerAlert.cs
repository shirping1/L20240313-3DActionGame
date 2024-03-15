using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �˸�â
public class DialongControllerAlert : DialogController
{
    // ����
    public Text LabelTitle;

    // ����
    public Text labelMessage;
    

    // Ŭ�������� ������ �˸�â�� �����͸� ��ü ����
    DialogDataAlert Data { get; set; }

    public void OnClickOk()
    {
        if(Data != null && Data.Callback != null)
        {
            Data.Callback();
        }
        // �۾��� ���� �� ������ �˾� â�� �����ڿ��� ����
        DialogManager.Instance.Pop();
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        // �����Ͱ� �˶��� �ƴ� ���
        if(!(data is DialogDataAlert))
        {
            // ���� �޽��� ���
            Debug.LogError("Invaild dialog data!");
            return; // �۾� ����
        }
        // �����͸� �ȳ� �����ͷν� �޾ƿ��ڽ��ϴ�.
        Data = data as DialogDataAlert;
        // �ؽ�Ʈ ���� �������� �Ӽ��� �����մϴ�.
        LabelTitle.text = Data.Title;
        labelMessage.text = Data.Message;
    }

    public override void Update()
    {
        base.Update();
        // �ν��Ͻ��� ���� Alert Ÿ���� ��Ʈ�ѷ��� �ٷ�� ������ ���
        DialogManager.Instance.Regist(DialogType.Alert, this);
    }
}
