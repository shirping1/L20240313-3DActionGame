using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogData
{
    // ���̾�α� Ÿ�Կ� ���� ������Ƽ
    public DialogType Type { get; set; }

    // ���̾�α� Ÿ���� �Ű������� ���̾�α� ������ ����(������)
    public DialogData(DialogType type)
    {
        Type = type;    
    }
}
