using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("�÷��̾� ������")]
    public int normalDamage = 10;
    public int skillDamage = 30;
    public int dashDamage = 30;

    [Header("���� ���")]
    public NormalTarget normalTarget;
    public SkillTarget skillTarget;

    /// <summary>
    /// �Ϲ� ���� �� ȣ��� �Լ�
    /// </summary>
    public void NormalAttack()
    {
        // ��� Ÿ���� ����Ʈ �ʱ�ȭ
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        // Ÿ�� ����Ʈ ���� ���͸� ��ü ��ȸ
        foreach(var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            // ���Ϳ��� �������� �ֱ�
            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(normalDamage, transform.position, 0.5f, 0.5f));
            }
        }
    }
    /// <summary>
    /// ��ų ���ݽ� ȣ��� �Լ�
    /// </summary>
    public void SkillAttack() 
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        // Ÿ�� ����Ʈ ���� ���͸� ��ü ��ȸ
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            // ���Ϳ��� �������� �ֱ�
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(skillDamage, transform.position, 1.0f, 2.0f));
            }
        }
    }
    /// <summary>
    ///  �뽬 ��ų ���� ȣ��
    /// </summary>
    public void DashAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);
        // Ÿ�� ����Ʈ ���� ���͸� ��ü ��ȸ
        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();
            // ���Ϳ��� �������� �ֱ�
            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(dashDamage, transform.position, 1.0f, 2.0f));
            }
        }
    }
}
