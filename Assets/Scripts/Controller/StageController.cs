using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ���������� �����ϴ� ��Ʈ�ѷ�
// �������� ���۰� ���� ������ ���������� ���۰� ������ ó���ϴ� ���
// �������� ������ ȹ���ϴ� ����Ʈ�� �����ϴ� �ý���

public class StageController : MonoBehaviour
{
    #region Field
    // ������������ ���� ����Ʈ�� ������ ����
    public int StagePoint = 0;
    // ����Ʈ ǥ�ÿ� �ؽ�Ʈ
    public Text PointText;
    #endregion

    #region Singleton
    // �������� ��Ʈ�ѷ��� �ν��Ͻ��� �����ϴ� ����ƽ ����
    public static StageController instance;
    // �ٸ� �ڵ� ������ StageController.instance.AddPoint(10)�� ���� ���·� ����� �� �ְ� �˴ϴ�.
    // ���� �����ؼ� �� �ʿ䰡 ��� ��


    private void Start()
    {
        instance = this;
        DialogDataAlert alert = new DialogDataAlert("Start", "All destroy slime", delegate () { Debug.Log("OK�� �������ϴ�!"); });

        DialogManager.Instance.Push(alert);
    }
    #endregion
    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Please press OK if you want restart the game.",
            delegate (bool yn)
            {
                if (yn)
                {
                    // Application.LoadLevel(Application.loadedLevel); �� ���� �ڵ�(����� ���� �ʽ��ϴ�.)
                    SceneManager.LoadScene("Game");
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                    Application.Quit();
            });
        DialogManager.Instance.Push(confirm);
    }
}
