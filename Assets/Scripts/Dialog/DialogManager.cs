using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// ���̾�α��� ������ �����ϴ� enum ����
/// </summary>
public enum DialogType
{
    Alert,
    Confirm,
    Ranking
}
// ����� ���� ���ϰ� �����ϴ� Ű���� sealed
// �� Ÿ�� �� Ư�� �Լ� ȣ���� ��� �θ�, �ڽ� Ŭ������ ��ü ������ ���������� ����� �Լ��� ã��
// sealedó���� Ŭ������ �� ������ ����
public sealed class DialogManager
{
    List<DialogData> _dialogQueue;
    Dictionary<DialogType, DialogController> _dialogMap;
    DialogController _currentDialog; // ���� ������� ���̾�α�(��ȭâ)
    #region SingleTon
    // �ڱ� �ڽſ� ���� static ������ ����
    private static DialogManager instance = new DialogManager();

    // ������Ƽ�� ���� ����
    public static DialogManager Instance
    {
        get { return instance; }
    }

    // ���� �� ���̾�α� ť�� ���̾�α� ���� �ʱ�ȭ
    private DialogManager()
    {
        _dialogQueue = new List<DialogData>();
        _dialogMap = new Dictionary<DialogType, DialogController>();
    }
    #endregion

    public void Regist(DialogType type, DialogController controller)
    {
        // ��ųʸ���[Ű] = ��;
        // �ش� Ű�� ���� ���� ��������ϴ�.
        _dialogMap[type] = controller; // == _dialogMap.Add(type, controller);
    }

    // �����͸� �ֻ�ܿ� ����
    // ���̾�α� ����Ʈ�� �����ϴ� ���̾�α� ť�� ���ο� ���̾�α� �����͸� �߰��ϴ� ����
    public void Push(DialogData data)
    {
        _dialogQueue.Add(data);

        if(_currentDialog ==  null)
        {
            ShowNext();
        }
    }

    // ������ �ֻ���� ���� ����
    // ����Ʈ���� ���������� ���� ���̾�α׸� �ݴ� ���
    public void Pop() 
    {
        // ���̾�αװ� ������ ��
        if(_currentDialog != null)
        {
            // �͸� delegate
            // delegate(�Ű����� ���){ �����ϰ��� �ϴ� �ڵ� };
            // �Լ� �̸� ���� ��ɸ� ��������Ʈ�� �Ҵ��ϱ� ���� ����
            _currentDialog.Close(
                delegate
                {
                    _currentDialog = null;
                    if(_dialogQueue.Count > 0 )
                    {
                        ShowNext();
                    }
                }
                );
        }
    }

    private void ShowNext()
    {
        // ���̾�α׸� ����Ʈ���� ù��° ���� ������
        var next = _dialogQueue[0];

        // ������ ���� ���¸� Ȯ���� � ��Ʈ�ѷ������� Ȯ���մϴ�.
        var controller = _dialogMap[next.Type].GetComponent<DialogController>();

        // ��ȸ�� ���̾�α� ��Ʈ�ѷ��� ������ ���̾�α� ��Ʈ�ѷ��� ������
        _currentDialog = controller;

        // ������ ���̾�α׸� ������
        _currentDialog.Build(next);

        //���̾�α׸� ȭ�鿡 �����ִ� �۾�
        _currentDialog.Show(delegate { } );

        // ���̾�α� ����Ʈ���� ������ �����͸� ����
        _dialogQueue.RemoveAt(0);

    }

    // ���� �˾� â�� ǥ�õǰ� �ִ����� Ȯ���ϴ� ����
    // _current�� ����ִ� ���� ���ٰ� �Ǵ�
    public bool IsShowing() => _currentDialog != null;



}
