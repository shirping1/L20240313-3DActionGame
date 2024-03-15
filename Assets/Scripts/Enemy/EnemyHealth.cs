using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Field
    [Header("�������� ü�� ����")]
    public int startHealth = 100;
    public int currentHealth;

    [Header("���u ���� �� �� ����")]
    public float flashSpeed = 5.0f;
    public Color flashColor = new Color(1, 0, 0, 0.1f);

    [Header("���� ���� ó��")]
    public float sinkSpeed = 1.0f;

    AudioSource audioSource;
    
    // �������� ���¸� ������ ��Ȳ�� �´� ȿ���� �����ӿ��� ����
    bool isDead;
    bool isSinking;
    bool damaged;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = startHealth;

    }

    // Update is called once per frame
    void Update()
    {
        // �������� ������ ���� ����
        if(damaged)
        {
            // Slime -> Model�� ����
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", flashColor);
        }
        // �װ� �ƴ� ��� �ٽ� �ڿ������� ���� ��ȯ�� �� �ֵ��� ó��
        // Color.Lerp(A,B); => A ���� B �� õõ�� ���� �ٲ�
        else
        {
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(transform.GetChild(0).
                GetComponent<Renderer>().material.GetColor("_Color"), Color.white, flashSpeed * Time.deltaTime));
        }

        // ������ ó���� ��Ȱ��ȭ
        damaged = false;

        // ��ũ ó��(���� ó��)�� �������� �Ʒ��� ������ �������� ����
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// �������� �÷��̾�κ��� ������ �޾��� ���� ��Ȳ�� ó���ϴ� �Լ�
    /// </summary>
    /// <param name="amount">������ ��ġ</param>
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if(currentHealth <= 0 && !isDead) 
        {
            Death();
        }
    }
    /// <summary>
    /// �������� �÷��̾�κ��� ������ �޾��� �� �˹� ȿ�� ����
    /// </summary>
    /// <param name="damage">������</param>
    /// <param name="playerPosition">�÷��̾���ġ</param>
    /// <param name="delay">������</param>
    /// <param name="pushback">Ǫ����</param>
    /// <returns></returns>
    public IEnumerator StartDamage(int damage, Vector3 playerPosition, float delay, float pushback)
    {
        yield return new WaitForSeconds(delay);

        try
        {
            TakeDamage(damage);
            Vector3 diff = playerPosition - transform.position;
            diff /= diff.sqrMagnitude;
            GetComponent<Rigidbody>().AddForce((transform.position - new Vector3(diff.x, diff.y, 0.0f)) * 50f * pushback);
        }
        catch (MissingReferenceException e)
        {
            Debug.LogError(e.ToString());
        }
    }

    /// <summary>
    /// �������� ������ ȣ���� �Լ�
    /// </summary>
    void Death()
    {
        isDead = true;

        StageController.instance.AddPoint(10);

        transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;

        // �ִϸ��̼� Ʈ���� �۵�

        // ���� �� ����� Ŭ������ ������ ����� ����

        StartSinking();
    }

    /// <summary>
    /// ���� ó��
    /// </summary>
    public void StartSinking()
    {
        //
        GetComponent<NavMeshAgent>().enabled = false;

        // �ܺο��� �������� �������� ���� ���� X
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 3.0f);
    }
}
