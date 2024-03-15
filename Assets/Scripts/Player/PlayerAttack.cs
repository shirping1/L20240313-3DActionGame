using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("플레이어 데미지")]
    public int normalDamage = 10;
    public int skillDamage = 30;
    public int dashDamage = 30;

    [Header("공격 대상")]
    public NormalTarget normalTarget;
    public SkillTarget skillTarget;

    /// <summary>
    /// 일반 공격 시 호출될 함수
    /// </summary>
    public void NormalAttack()
    {
        // 노멀 타켓의 리스트 초기화
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        // 타겟 리스트 안의 몬스터를 전체 조회
        foreach(var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            // 몬스터에게 데미지를 주기
            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(normalDamage, transform.position, 0.5f, 0.5f));
            }
        }
    }
    /// <summary>
    /// 스킬 공격시 호출될 함수
    /// </summary>
    public void SkillAttack() 
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        // 타겟 리스트 안의 몬스터를 전체 조회
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            // 몬스터에게 데미지를 주기
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(skillDamage, transform.position, 1.0f, 2.0f));
            }
        }
    }
    /// <summary>
    ///  대쉬 스킬 사용시 호출
    /// </summary>
    public void DashAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        // 타겟 리스트 안의 몬스터를 전체 조회
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            // 몬스터에게 데미지를 주기
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(dashDamage, transform.position, 1.0f, 2.0f));
            }
        }
    }
}
