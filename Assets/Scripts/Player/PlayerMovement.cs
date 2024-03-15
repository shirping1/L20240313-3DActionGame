using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    protected PlayerAttack playerAttack;
    float h, v;

    // 시간 체크용 변수
    float lastAttackTime, lastSkillTime, lastDashTime;

    [Header("Animation Condition")]
    public bool attacking = false;
    public bool dashing = false;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void OnStickChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        float back = 1.0f;
        if (v < 0)
        {
            back = -1.0f;
        }
        if (avatar)
        {
            avatar.SetFloat("Speed", (h * h + v * v));
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            if(rigidbody)
            {
                if(h != 0.0f &&  v != 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0f, v));
                }
            }
        }
    }
    #region EventTrigger
    public void OnAttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());
        //StartCoroutine("StartAttack"); 위와 동일 코드
        // 코루틴은 Update가 아닌 영역에서 반복적으로 코드가 실행되어야 할 때 사용하면 효과적
        // Update에서 무분별하게 돌리는 코드를 코루틴으로 전환하면 자원관리에 효과적
        // 코루틴은 일정 시간 멈추고 뒤에 움직이는 작업, 특정 조건을 부여해 코드를 실행하는 작업에 용이
        // 코루틴은 IEnumerator 형태의 함수를 시작 yield return문이 존재 해야함
        // 코루틴은 반복 루틴에서 탈출하고 다시 그 시점으로 돌아오는 것이 가능
    }

    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking= false;
    }

    // yield문은 다음 요소를 제공하는 키워드
    IEnumerator StartAttack()
    {
        if(Time.time - lastAttackTime > 1.0f)
        {
            lastAttackTime = Time.time;
            while(attacking)
            {
                avatar.SetTrigger("AttackStart");
                playerAttack.NormalAttack();    
                yield return new WaitForSeconds(1.0f);

            }
        }
    }

    /// <summary>
    /// 버튼 2번 누르면 나갈 스킬
    /// </summary>
    public void OnSkillDown()
    {
        if(Time.time - lastSkillTime > 1.0f)
        {
            avatar.SetBool("Skill", true);
            lastSkillTime = Time.time;
            playerAttack.SkillAttack();
        }
    }
    public void OnSkillUp()
    {
        avatar.SetBool("Skill", false);
    }

    /// <summary>
    /// 버툰 1번 누르면 나갈 스킬
    /// </summary>
    public void OnDashDown()
    {
        if (Time.time - lastDashTime > 1.0f)
        {
            dashing = true;
            lastDashTime = Time.time;
            avatar.SetTrigger("Dash");
            playerAttack.DashAttack();
        }
    }
    public void OnDashUp()
    {
        dashing = false;
    }

    #endregion


}
