using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//�˸�â���� ����� ������
public class DialogDataAlert : DialogData
{
    public string Title { get; private set; }
    public string Message { get; private set; }
    //����Ƽ���� ����� ���ִ� delegate Action
    //������ Ȯ�� ��ư ������ �� ȣ��Ǵ� �ݹ� �Լ��� �����ϰڽ��ϴ�.
    //�ݹ� �Լ�
    public Action Callback { get; private set; }

    //Action callback = null
    //default �Ű������� �Ű������� ���� �ʱ�ȭ�صδ� ������,
    //�Լ� ȣ�� �ÿ� �ش� ���� �ȳְ� ȣ���ϴ� ��� �����ص� �ʱ� ������ �ڵ����� ó���ϴ� ���

    //base(DialogType.Alert)

    public DialogDataAlert(string title, string message, Action callback = null) : base(DialogType.Alert)
    {
        Title = title;
        Message = message;
        Callback = callback;
    }

}

