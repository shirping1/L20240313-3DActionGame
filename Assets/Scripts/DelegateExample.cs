using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Delegate?
// C/C++ �� �Լ� �����Ϳ� ����� ����

// Delegate�� �Լ� Ÿ�Կ� ���� ���� �� �����ϰ�
// �Ű������� ���� ���踦 ������ ���
// ���� Ÿ��, ���� �Ű������� ���� �޼ҵ带 �ҷ��� ����� �� �ִ� ���� (�븮��)

public class DelegateExample : MonoBehaviour
{
    // 1. Delegate ����
    delegate void DelegateTester();

    // 2. delegate�� ������ ���¿� ������ �Լ��� ����
    void DelegateTester01()
    {
        Debug.Log("�븮�� �׽�Ʈ 1");
    }

    void DelegateTester02()
    {
        Debug.Log("�븮�� �׽�Ʈ 2");
    }

    // Start is called before the first frame update
    void Start()
    {
        //delegate ���� -> delegate�� ������ = new delegate��(�Լ���);
        DelegateTester delegateTester = new DelegateTester(DelegateTester01);

        // delegate ȣ��
        delegateTester();

        delegateTester = DelegateTester02; // delegate�� ó���� �Լ� ����

        delegateTester();
    }
}
