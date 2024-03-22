using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// event(�̺�Ʈ) : ��ü���� �۾� ������ �˸��� ���� ������ �޼���
// �̺�Ʈ�� �ܺ� ������(subscriber)���� Ư�� ���� �˷��ִ� ����� �����ϴ�.

// Event Handler(�̺�Ʈ �ڵ鷯) : �����ڰ� �̺�Ʈ�� �߻��� ��� � ����� ������ �� �������ִ� �� 
// +=�� ���� �̺�Ʈ�� ����  �߰��� ����, -=�� ���� �̺�Ʈ�� �����ϴ� �͵� ����
// �̺�Ʈ �߻� �� �߰��� �ڵ鷯�� ���������� ȣ��

class ClickEvent
{
    public event EventHandler Click;

    public void MouseButtonDown()
    {
        if(Click != null)
        {
            Click(this, EventArgs.Empty);
            // EventArgs �̺�Ʈ ���� �� �Ķ���ͷ� �����͸� �ް� ���� ��� �ش� Ŭ������ ��ӹ޾� ���
            // EventArgs�� �̺�Ʈ �߻��� ���õ� ������ ������ ����
            // �̺�Ʈ �ڵ鷯�� ����ϴ� �Ķ���� ����
        }
    }
}



public class UnityEventExample : MonoBehaviour
{
    ClickEvent clickEvent;
    DailyCheck dailyCheck;
    public Text eventText;
    string dialog;
    // Start is called before the first frame update
    void Start()
    {
        clickEvent = new ClickEvent();
        clickEvent.Click += new EventHandler(ButtonClick);
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        Debug.Log("��ư�� Ŭ���߽��ϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            clickEvent.MouseButtonDown();
        }
    }
}
