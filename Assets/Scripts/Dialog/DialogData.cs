using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DialogData
{
    //���̾�α� Ÿ�Կ� ���� ������Ƽ
    public DialogType Type { get;  internal set; }

    //���̾�α� Ÿ���� �Ű������� ���̾�α� ������ ����(������)
    public DialogData(DialogType type)
    {
        Type = type;
    }
}

