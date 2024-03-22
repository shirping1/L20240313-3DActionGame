using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ���̾�α��� ������ �����ϴ� enum ����
/// </summary>
public enum DialogType
{
    Alert,
    Confirm,
    Ranking
}

//��� ���ް� ���� �Ŵ� Ű���� sealed
//�� Ÿ�� �� Ư�� �Լ� ȣ���� ��� �θ�, �ڽ� Ŭ������ ��ü ������
//���������� ����� �Լ��� ã�� �˴ϴ�.
//sealed ó���� Ŭ������ �� ������ ������ �� �ְ� ���ݴϴ�.
public sealed class DialogManager
{
    List<DialogData> _dialogQueue;
    Dictionary<DialogType, DialogController> _dialogMap;
    DialogController _currentDialog; //���� ������� ���̾�α�(��ȭâ)

    #region Singleton   
    //�ڱ� �ڽſ� ���� static ������ ���� 
    private static DialogManager instance = new DialogManager();
    //C++ : Map
    //Python : dict
    //C# : Dictionary
    //Java : HashMap
    //������Ƽ�� ���� ����
    public static DialogManager Instance
    {
        get
        {
            return instance;
        }
    }
    //���� �� ���̾�α� ť�� ���̾�α� ���� �ʱ�ȭ�մϴ�.
    private DialogManager()
    {
        _dialogQueue = new List<DialogData>();
        _dialogMap = new Dictionary<DialogType, DialogController>();
    }
    #endregion
    public void Regist(DialogType type, DialogController controller)
    {
        //��ųʸ���[Ű] = ��;
        //�ش� Ű�� ���� ���� ��������ϴ�. (Ű : �� )
        _dialogMap[type] = controller;
        //_dialogMap.Add(type, controller);
    }

    //�����͸� �ֻ�ܿ� �����ϴ� ����
    //���̾�α� ����Ʈ�� �����ϴ� ���̾�α� ť�� ���ο� ���̾�α� �����͸� �߰��ϴ� ����
    public void Push(DialogData data)
    {
        _dialogQueue.Add(data);

        if (_currentDialog == null)
            ShowNext();
    }

    //������ �ֻ���� ���� �����ϴ� ����
    // ����Ʈ���� ���������� ���� ���̾�α׸� �ݴ� ���
    public void Pop()
    {
        //���̾�αװ� ������ ��
        if (_currentDialog != null)
        {
            //�͸� delegate
            //delegate(�Ű����� ���) { �����ϰ��� �ϴ� �ڵ� };
            //�Լ� �̸� ���� ��ɸ� ��������Ʈ�� �Ҵ��ϱ� ���� ����
            _currentDialog.Close(
                delegate
                {
                    _currentDialog = null;
                    if (_dialogQueue.Count > 0)
                    {
                        ShowNext();
                    }
                });
        }
    }

    private void ShowNext()
    {
        //���̾�α׸� ����Ʈ���� ù��° ���� �������ڽ��ϴ�.
        DialogData next = _dialogQueue[0];
        //������ ���� ���¸� Ȯ���� � ��Ʈ�ѷ������� Ȯ���մϴ�.
        DialogController controller = _dialogMap[next.Type].GetComponent<DialogController>();
        //��ȸ�� ���̾�α� ��Ʈ�ѷ��� ������ ���̾�α� ��Ʈ�ѷ��� �����մϴ�.
        _currentDialog = controller;
        //������ ���̾�α׸� �����ϰڽ��ϴ�.
        _currentDialog.Build(next);
        //���̾�α׸� ȭ�鿡 �����ְڽ��ϴ�.
        _currentDialog.Show(delegate { });
        //���̾�α� ����Ʈ���� ������ �����͸� �����ϰڽ��ϴ�.
        _dialogQueue.RemoveAt(0);
    }

    //���� �˾� â�� ǥ�õǰ� �ִ����� Ȯ���ϴ� ����
    //_current�� ����ִ� ���� ���ٰ� �Ǵ��ϰڽ��ϴ�.
    public bool IsShowing() => _currentDialog != null;


}

