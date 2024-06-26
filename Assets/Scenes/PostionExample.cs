using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionExample : MonoBehaviour
{
    public bool isUse;
    public float cooltime = 10.0f;
    public float cooltime_max = 10.0f;

    public void OnPotionDown()
    {
        if (isUse == false)
        {
            Debug.Log("포션을 사용했습니다!");
            StartCoroutine(CoolTimeCheck());
            GetComponent<Image>().color = Color.black;
            isUse = true;
        }
    }

    IEnumerator CoolTimeCheck()
    {
        while (cooltime > 0.0f)
        {
            GetComponent<Image>().color = Color.black;
            isUse = true;

            cooltime -= Time.deltaTime;
            GetComponent<Image>().fillAmount = cooltime / cooltime_max;

            yield return null;
        }

        Debug.Log("쿨타임 체크 완료");
        GetComponent<Image>().color = Color.red;
        GetComponent<Image>().fillAmount = 1.0f;
        cooltime = 10.0f;
        isUse = false;
    }
}
