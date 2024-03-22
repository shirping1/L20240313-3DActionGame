using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogControllerAlert : DialogController
{
    public Text LabelTitle;
    public Text LabelMessage;

    DialogDataAlert Data
    {
        get;
        set;
    }

    DialogControllerAlert()
    {
        // �Ŵ��� ��ü�� Ȯ��â ���
        DialogManager.Instance.Regist(DialogType.Alert, this);

    }

    #region Virtual override
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();

    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        // �����Ͱ� ���� �� Build���� �� �α׸� ����
        if (!(data is DialogDataAlert))
        {
            Debug.LogError("Invalid dialog data!");
            return;
        }

        Data = data as DialogDataAlert;
        LabelTitle.text = Data.Title;
        LabelMessage.text = Data.Message;
    }

    #endregion

    public void OnClickOK()
    {
        // ������, �ݹ� �� �����ϸ�
        // calls child's callback
        if (Data != null && Data.Callback != null)
        {
            // �����Ϳ� ���� �ݹ� �Լ� ȣ��
            Data.Callback();
            // �Ŵ��� ��ü�� ���� ���˾��� �Ŵ������� ����
            DialogManager.Instance.Pop();
        }
    }
}