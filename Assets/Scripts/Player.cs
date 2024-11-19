using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��
    public int baseAttackPower = 10; // �÷��̾��� �⺻ ���ݷ�
    public int attackPowerIncrement = 1; // ���ݷ� ������

    public Slider healthSlider; // ü�� �� UI Slider
    public Text attackPowerText; // ���ݷ��� ǥ���� UI Text

    public int attackPower = 10; // ���� ���ݷ�

    void Start()
    {
        // ���� �� �̸� ��������
        string currentSceneName = SceneManager.GetActiveScene().name;

        // StageScene1���� ������ �� PlayerPrefs �ʱ�ȭ
        if (currentSceneName == "StageScene1")
        {
            ResetPlayerData();
        }
        else
        {
            LoadPlayerData(); // ���� ���� �� �÷��̾� ������ �ε�
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
        SavePlayerData(); // �÷��̾ ���ظ� �Ծ��� �� ������ ����
    }

    void UpdateHealthUI() //�÷��̾��� ü�� ������Ʈ
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }

    void UpdateAttackPowerUI() //�÷��̾��� ���ݷ� ������Ʈ
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
        // �÷��̾ �׾��� ���� ����
        Debug.Log("�÷��̾ �׾����ϴ�.");
        SavePlayerData(); // �÷��̾ ���� �� ������ ����
        SceneManager.LoadScene("GameOverScene"); // ���� ���� ������ ��ȯ
    }

    // ���� ���� ������ ���ݷ� ����
    public void IncreaseAttackPower()
    {
        attackPower += attackPowerIncrement; //���ݷ� ����
        UpdateAttackPowerUI();
        SavePlayerData(); // �÷��̾ ���� ���� �� ������ ����
    }

    void SavePlayerData()
    {
        // �÷��̾��� ü�°� ���ݷ��� PlayerPrefs�� ����
        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.SetInt("PlayerAttackPower", attackPower);
        PlayerPrefs.Save(); // ���� ������ ����
    }

    void LoadPlayerData()
    {
        // PlayerPrefs���� �÷��̾��� ü�°� ���ݷ��� �ҷ��� �Ҵ�
        currentHealth = PlayerPrefs.GetInt("PlayerHealth", maxHealth); // ����� ���� ���� ��� �⺻������ ����
        attackPower = PlayerPrefs.GetInt("PlayerAttackPower", baseAttackPower); // ����� ���� ���� ��� �⺻������ ����
    }

    void ResetPlayerData()
    {
        // PlayerPrefs �ʱ�ȭ
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerAttackPower");

        // �⺻������ �ʱ�ȭ
        currentHealth = maxHealth;
        attackPower = baseAttackPower;
    }
}
