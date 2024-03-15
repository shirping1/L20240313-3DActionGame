using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �˸�â���� ����� ������
public class DialogDataAlert : DialogData
{
    public string Title { get; private set; }

    public string Message { get; private set; }

    // ����Ƽ���� ����� ���ִ� delegate Action
    // ������ Ȯ�� ��ư ������ �� ȣ��Ǵ� �ݹ� �Լ��� �����ϰڽ��ϴ�.
    // �ݹ� �Լ�
    public Action Callback { get; private set; }

    public DialogDataAlert(string title, string message, Action callback = null) : base(DialogType.Alert)
    {
        Title = title;
        Message = message;
        Callback = callback;
    }


}
