using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; // 최대 체력
    public int currentHealth; // 현재 체력
    public int baseAttackPower = 10; // 플레이어의 기본 공격력
    public int attackPowerIncrement = 1; // 공격력 증가량

    public Slider healthSlider; // 체력 바 UI Slider
    public Text attackPowerText; // 공격력을 표시할 UI Text

    public int attackPower = 10; // 현재 공격력

    void Start()
    {
        // 현재 씬 이름 가져오기
        string currentSceneName = SceneManager.GetActiveScene().name;

        // StageScene1에서 시작할 때 PlayerPrefs 초기화
        if (currentSceneName == "StageScene1")
        {
            ResetPlayerData();
        }
        else
        {
            LoadPlayerData(); // 게임 시작 시 플레이어 데이터 로드
        }

        UpdateHealthUI();
        UpdateAttackPowerUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        UpdateHealthUI();
        SavePlayerData(); // 플레이어가 피해를 입었을 때 데이터 저장
    }

    void UpdateHealthUI() //플레이어의 체력 업데이트
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void UpdateAttackPowerUI() //플레이어의 공격력 업데이트
    {
        if (attackPowerText != null)
        {
            attackPowerText.text = "Attack Power: " + attackPower;
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        // 플레이어가 죽었을 때의 로직
        Debug.Log("플레이어가 죽었습니다.");
        SavePlayerData(); // 플레이어가 죽을 때 데이터 저장
        SceneManager.LoadScene("GameOverScene"); // 게임 오버 씬으로 전환
    }

    // 적을 죽일 때마다 공격력 증가
    public void IncreaseAttackPower()
    {
        attackPower += attackPowerIncrement; //공격력 증가
        UpdateAttackPowerUI();
        SavePlayerData(); // 플레이어가 적을 죽일 때 데이터 저장
    }

    void SavePlayerData()
    {
        // 플레이어의 체력과 공격력을 PlayerPrefs에 저장
        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.SetInt("PlayerAttackPower", attackPower);
        PlayerPrefs.Save(); // 변경 내용을 저장
    }

    void LoadPlayerData()
    {
        // PlayerPrefs에서 플레이어의 체력과 공격력을 불러와 할당
        currentHealth = PlayerPrefs.GetInt("PlayerHealth", maxHealth); // 저장된 값이 없을 경우 기본값으로 설정
        attackPower = PlayerPrefs.GetInt("PlayerAttackPower", baseAttackPower); // 저장된 값이 없을 경우 기본값으로 설정
    }

    void ResetPlayerData()
    {
        // PlayerPrefs 초기화
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerAttackPower");

        // 기본값으로 초기화
        currentHealth = maxHealth;
        attackPower = baseAttackPower;
    }
}
