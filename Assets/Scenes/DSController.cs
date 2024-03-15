using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


// 이벤트 트리거를 통해 전달

public class DSController : MonoBehaviour
{
    public Text ResultText;

    // 배열 사용
    public void DSArray()
    {
        // 자료형[] 배열명 = new 자료형[배열의 길이];
        int[] exp = new int[10];

        for (int i = 0; i < exp.Length; i++)
        {
            exp[i] = i * 100 + (i * 50);
            ResultText.text += $"[DSArray]다음 레벨{i}까지 요구 경험치 = {exp[i]} 입니다.\n";
        }
    }

    public void DSList()
    {
        // List<T> 리스트명 = new List<T>();
        List<int> exp = new List<int>();

        for(int i = 0; i < 10; i++)
        {
            exp.Add(i * 100 + (i * 50));
        }

        // 가지고 있는 데이터 값 중 4의 배수를 전부 삭제
        // exp.RemoveAll(x => x % 4 == 0);

        // 내림차순으로 정렬
        exp.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < exp.Count; i++)
        {
            ResultText.text += $"[DSList]다음 레벨{i}까지 요구 경험치 = {exp[i]} 입니다.\n";
        }
        // C#에서 사용되는 리스트 문법
        // 1. Add(값) : 해당 값을 리스트에 추가
        // 2, Remove(값) : 해당 값을 리스트에서 제거
        // 3. Insert(위치, 값) : 리스트의 해당 위치에 값을 추가
        // 4, Contains(값) : 리스트가 해당 값을 가지고 있는지를 판단 (bool)
        // 5. Clear() : 리스트의 모든 요소 제거
        // 6. Reverse() : 요소를 역순으로 정렬
        // 7. RemoveAll(조건) : 해당 조건을 만족하는 모든 요소를 삭제
        // 8. Sort() : 오름차순으로 정렬
        // 9. Sort((a , b) => b.CompareTo(a)); 내림차순
    }

    public void DSDictionary()
    {
        // 생성 Dictionary<K,V> 딕셔너리명 = new Dictionary<K,V>();

        // 생성및 초기화
        Dictionary<string, int> item = new Dictionary<string, int>
        {
            {"red apple", 10},
            {"meat", 100}
        };

        // 추가
        item.Add("cake", 50);

        // 키 조사
        if (item.ContainsKey("cake"))
        {
            item.Remove("cake");
        }

        if (item.ContainsValue(100))
        {
            Debug.Log("해당 값은 존재합니다.");
        }

        // 딕셔너리의 핵심
        // 1, 키를 이용한 값에 대한 접근
        // 2. 해당 키가 존재하는가에 대한 여부
        // 3. 키, 값을 각각 분할해 보관할 수 있는가
        // 4. 닥셔너리는 키의 경우에는 중복 허용 X, 값은 중복 O
        //    따라서 Add시 기존의 키를 다시 Add하는 경우 그 키가 가진 값만 변경

        // 딕셔너리의 키 -> 리스트로 바꾸는 기능
        var KList = new List<string>(item.Keys);

        // 딕셔너리의 값 -> 리스트로 바꾸는 기능
        var vList = new List<int>(item.Values);

        //리스트 -> 딕셔너리로 바꾸기
        // 1, 키가 될 리스트와 값이 될 리스트를 준비
        var KtoD = new List<string>() { "a", "b", "c", "d", "e" };
        var VtoD = new List<int>() { 1, 2, 3, 4, 5 };

        // 딕셔너리를 생성하고 Zip 함수를 통해 작업을 진행
        // 키.Zip(값, (k,v) => new {k,v}) 키와 값 하나하나가 {키,값}의 형태로 묶이게 됨
        // ToDictionary에 의해 키와 값을 설정 그리고 딕셔너리의 형태로 변환
        var NewDictionary = KtoD.Zip(VtoD, (k,v) => new { k, v }).ToDictionary(a => a.k, a => a.v);
    }



    // 해당 함수 호출시 화면에 나온 텍스트를 비우는 기능
    public void DSResultReset()
    {
        ResultText.text = "";
    }


}
