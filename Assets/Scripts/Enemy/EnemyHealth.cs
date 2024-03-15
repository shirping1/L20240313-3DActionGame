using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Field
    [Header("슬라임의 체력 정보")]
    public int startHealth = 100;
    public int currentHealth;

    [Header("공굑 받을 시 색 변경")]
    public float flashSpeed = 5.0f;
    public Color flashColor = new Color(1, 0, 0, 0.1f);

    [Header("죽은 이후 처리")]
    public float sinkSpeed = 1.0f;

    AudioSource audioSource;
    
    // 슬라임의 상태를 구분해 상황에 맞는 효과를 슬라임에게 전달
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
        // 데미지를 받을시 색을 변경
        if(damaged)
        {
            // Slime -> Model에 접근
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", flashColor);
        }
        // 그게 아닐 경우 다시 자연스럽게 색이 변환될 수 있도록 처리
        // Color.Lerp(A,B); => A 에서 B 로 천천히 색을 바꿈
        else
        {
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(transform.GetChild(0).
                GetComponent<Renderer>().material.GetColor("_Color"), Color.white, flashSpeed * Time.deltaTime));
        }

        // 데미지 처리를 비활성화
        damaged = false;

        // 싱크 처리(사후 처리)시 슬라임을 아래로 서서히 내려가게 연출
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// 슬라임이 플레이어로부터 공격을 받았을 때의 상황을 처리하는 함수
    /// </summary>
    /// <param name="amount">데미지 수치</param>
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
    /// 슬라임이 플레이어로부터 공격을 받았을 때 넉백 효과 연출
    /// </summary>
    /// <param name="damage">데미지</param>
    /// <param name="playerPosition">플레이어위치</param>
    /// <param name="delay">딜레이</param>
    /// <param name="pushback">푸쉬백</param>
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
    /// 슬라임의 죽음시 호출할 함수
    /// </summary>
    void Death()
    {
        isDead = true;

        StageController.instance.AddPoint(10);

        transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;

        // 애니메이션 트리거 작동

        // 죽을 때 사용할 클립으로 변경후 오디오 실행

        StartSinking();
    }

    /// <summary>
    /// 사후 처리
    /// </summary>
    public void StartSinking()
    {
        //
        GetComponent<NavMeshAgent>().enabled = false;

        // 외부에서 가해지는 물리적인 힘에 반응 X
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 3.0f);
    }
}
