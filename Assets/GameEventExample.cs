using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class DailyCheck
{

    public event EventHandler dailyCheckEvent;
    public int dailyCheck;

    public void DailyLogin()
    {
        if (dailyCheck == 100)
            dailyCheckEvent(this, EventArgs.Empty);

    }
}

public class GameEventExample : MonoBehaviour
{
    public int loginTime = 100;
    DailyCheck dailyCheck;
    public Text messageT;

    [Range(0.05f, 0.1f)] public float read_speed;
    string dialog;

    // Start is called before the first frame update
    void Start()
    {
        dailyCheck = new DailyCheck();
        dailyCheck.dailyCheck = loginTime;
        dialog = $"축하합니다. {dailyCheck.dailyCheck}번째 접속 유저입니다!\n 이벤트에 당첨되셨습니다.";
        dailyCheck.dailyCheckEvent += Check;

        dailyCheck.DailyLogin();
    }

    private void Check(object sender, EventArgs e)
    {
        StartCoroutine(TypingText(dialog));
    }

    IEnumerator TypingText(string message)
    {
        messageT.text = null;

        for (int i = 0; i < message.Length; i++)
        {
            messageT.text += message[i];
            yield return new WaitForSeconds(read_speed);
        }
    }
}
