using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ����Ƽ���� ����� �� �ִ� �븮�� ����
// 1. Action : ����Ƽ���� ��ȯ ���� ���� ���� void ������ �븮��
// 2. Func :  ����Ƽ���� ��ȯ ���� �ִ� ����
// 3. UnityEvent : �ν����Ϳ��� �̺�Ʈ�� ������� �Ҵ��� �� �ְ� ���ִ� ����
// 4. event
// 5. delegate


public class UnityDelegate : MonoBehaviour
{
    public UnityEvent onDead;

    private void Awake()
    {
        onDead.AddListener(Dead); // ��ũ��Ʈ�� ���� onDead�� �̺�Ʈ �Լ� ���
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            onDead.Invoke();
        }
    }

    void Dead()
    {
        Debug.Log("�׾���");
    }

    Action testAction01;

    void Method01() { }
    void Method02() { }
    void Method03() { }

    int Method04() { return 1; }

    Action<int> testAction02; // �׼��� <> �ȿ� �ִ� ���� delegate�� ȣ���� �Լ��� �Ű���

    void Method05(int a) {  }
    void Method06(int b) {  }
    void Method07(int c) {  }

    Func<bool> testFunce01;
    
    bool Method08() { return true; } 
    bool Method09() { return false; }

    Func<int, int, int> testFunce02; // �� �������� ���� ���� Ÿ�� int �� ����Ÿ�� �׾��� ���� �Ű�����

    int Method10(int a, int b) { return a + b; }
    int Method11(int a, int b) { return a - b; }

    void ActionMethod(Action<bool> callback)
    {
        callback(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        testAction01 += Method01;
        testAction01 += Method02;
        testAction01 += Method03;
        // testAction01 += Method04; ����
        testAction01();

        testAction02 += Method05;
        testAction02 += Method06;
        testAction02 += Method07;
        testAction02(10); // �븮�� ȣ��
        testAction02?.Invoke(10); // �븮���� invoke ��� ����
        // �Ʒ��� �ڵ�� ?�� ���� null üũ�� ������ �� �־� nullreferenceException�� ���� ��Ȳ�ľ� ����

        testFunce01 += Method08;
        testFunce01 += Method09;

        if(testFunce01?.Invoke() == true)
        {
            Debug.Log("�۾� ����");
        }
        else
        {
            Debug.Log("�۾� ����2");
        }

        testFunce02 += Method10;
        testFunce02 += Method11;

        Debug.Log(testFunce02?.Invoke(10, 5));


    }

}
