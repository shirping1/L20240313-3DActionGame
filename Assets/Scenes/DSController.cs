using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


// �̺�Ʈ Ʈ���Ÿ� ���� ����

public class DSController : MonoBehaviour
{
    public Text ResultText;

    // �迭 ���
    public void DSArray()
    {
        // �ڷ���[] �迭�� = new �ڷ���[�迭�� ����];
        int[] exp = new int[10];

        for (int i = 0; i < exp.Length; i++)
        {
            exp[i] = i * 100 + (i * 50);
            ResultText.text += $"[DSArray]���� ����{i}���� �䱸 ����ġ = {exp[i]} �Դϴ�.\n";
        }
    }

    public void DSList()
    {
        // List<T> ����Ʈ�� = new List<T>();
        List<int> exp = new List<int>();

        for(int i = 0; i < 10; i++)
        {
            exp.Add(i * 100 + (i * 50));
        }

        // ������ �ִ� ������ �� �� 4�� ����� ���� ����
        // exp.RemoveAll(x => x % 4 == 0);

        // ������������ ����
        exp.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < exp.Count; i++)
        {
            ResultText.text += $"[DSList]���� ����{i}���� �䱸 ����ġ = {exp[i]} �Դϴ�.\n";
        }
        // C#���� ���Ǵ� ����Ʈ ����
        // 1. Add(��) : �ش� ���� ����Ʈ�� �߰�
        // 2, Remove(��) : �ش� ���� ����Ʈ���� ����
        // 3. Insert(��ġ, ��) : ����Ʈ�� �ش� ��ġ�� ���� �߰�
        // 4, Contains(��) : ����Ʈ�� �ش� ���� ������ �ִ����� �Ǵ� (bool)
        // 5. Clear() : ����Ʈ�� ��� ��� ����
        // 6. Reverse() : ��Ҹ� �������� ����
        // 7. RemoveAll(����) : �ش� ������ �����ϴ� ��� ��Ҹ� ����
        // 8. Sort() : ������������ ����
        // 9. Sort((a , b) => b.CompareTo(a)); ��������
    }

    public void DSDictionary()
    {
        // ���� Dictionary<K,V> ��ųʸ��� = new Dictionary<K,V>();

        // ������ �ʱ�ȭ
        Dictionary<string, int> item = new Dictionary<string, int>
        {
            {"red apple", 10},
            {"meat", 100}
        };

        // �߰�
        item.Add("cake", 50);

        // Ű ����
        if (item.ContainsKey("cake"))
        {
            item.Remove("cake");
        }

        if (item.ContainsValue(100))
        {
            Debug.Log("�ش� ���� �����մϴ�.");
        }

        // ��ųʸ��� �ٽ�
        // 1, Ű�� �̿��� ���� ���� ����
        // 2. �ش� Ű�� �����ϴ°��� ���� ����
        // 3. Ű, ���� ���� ������ ������ �� �ִ°�
        // 4. �ڼųʸ��� Ű�� ��쿡�� �ߺ� ��� X, ���� �ߺ� O
        //    ���� Add�� ������ Ű�� �ٽ� Add�ϴ� ��� �� Ű�� ���� ���� ����

        // ��ųʸ��� Ű -> ����Ʈ�� �ٲٴ� ���
        var KList = new List<string>(item.Keys);

        // ��ųʸ��� �� -> ����Ʈ�� �ٲٴ� ���
        var vList = new List<int>(item.Values);

        //����Ʈ -> ��ųʸ��� �ٲٱ�
        // 1, Ű�� �� ����Ʈ�� ���� �� ����Ʈ�� �غ�
        var KtoD = new List<string>() { "a", "b", "c", "d", "e" };
        var VtoD = new List<int>() { 1, 2, 3, 4, 5 };

        // ��ųʸ��� �����ϰ� Zip �Լ��� ���� �۾��� ����
        // Ű.Zip(��, (k,v) => new {k,v}) Ű�� �� �ϳ��ϳ��� {Ű,��}�� ���·� ���̰� ��
        // ToDictionary�� ���� Ű�� ���� ���� �׸��� ��ųʸ��� ���·� ��ȯ
        var NewDictionary = KtoD.Zip(VtoD, (k,v) => new { k, v }).ToDictionary(a => a.k, a => a.v);
    }



    // �ش� �Լ� ȣ��� ȭ�鿡 ���� �ؽ�Ʈ�� ���� ���
    public void DSResultReset()
    {
        ResultText.text = "";
    }


}
