
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deadText;

    public int startingHealth = 100;

    // 현재 체력
    public int currentHealth;

    public Slider healthSlider;

    //데미지 받을때 화면 색 변경
    public Image damageImage;

    // 플레이어 데미지 받았을때 재생할 오디어
    public AudioClip deathClip;

    //애니메이터에 전달
    Animator anim;
    // 효과음 듣기 위한 컴포넌트
    AudioSource playerAudio;
    // 플레이어 움직임 관리
    PlayerMovement playerMovement;
    // 플레이어가 죽었는지
    bool isDead;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }
    /// <summary>
    /// 플레이어가 공격을 받았을때 호출되는 함수
    /// </summary>
    /// <param name="amount"> 데미지 수치</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        else
        {
            anim.SetTrigger("Damage");
        }
    }
    public void Death()
    {
        StageController.instance.FinishGame();
        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        deadText.SetActive(true);
    }
}

