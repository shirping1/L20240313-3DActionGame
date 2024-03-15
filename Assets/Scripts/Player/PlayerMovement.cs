using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    protected PlayerAttack playerAttack;
    float h, v;

    // �ð� üũ�� ����
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
        //StartCoroutine("StartAttack"); ���� ���� �ڵ�
        // �ڷ�ƾ�� Update�� �ƴ� �������� �ݺ������� �ڵ尡 ����Ǿ�� �� �� ����ϸ� ȿ����
        // Update���� ���к��ϰ� ������ �ڵ带 �ڷ�ƾ���� ��ȯ�ϸ� �ڿ������� ȿ����
        // �ڷ�ƾ�� ���� �ð� ���߰� �ڿ� �����̴� �۾�, Ư�� ������ �ο��� �ڵ带 �����ϴ� �۾��� ����
        // �ڷ�ƾ�� IEnumerator ������ �Լ��� ���� yield return���� ���� �ؾ���
        // �ڷ�ƾ�� �ݺ� ��ƾ���� Ż���ϰ� �ٽ� �� �������� ���ƿ��� ���� ����
    }

    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking= false;
    }

    // yield���� ���� ��Ҹ� �����ϴ� Ű����
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
    /// ��ư 2�� ������ ���� ��ų
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
    /// ���� 1�� ������ ���� ��ų
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
