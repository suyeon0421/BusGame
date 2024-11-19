using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance; // ���� �Ŵ����� �ν��Ͻ�

    private int score = 0; // ���� ���ھ�
    public Text scoreText; // UI�� ǥ���� ���ھ� �ؽ�Ʈ
    public float gameTime = 30f; // ���� �ð� (��)
    private float timer = 0f; // ���� ����� �ð�
    private bool isGameOver = false; // ���� ���� ����

    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>(); // ���ھ� ���� �̺�Ʈ

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // �ν��Ͻ��� ������ �ڽ��� ����
        }
        else if (instance != this)
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� ������ �ڽ��� �ı�
        }
    }

    private void Start()
    {
        timer = gameTime; // Ÿ�̸� �ʱ�ȭ
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime; // Ÿ�̸� ����

            if (timer <= 0) // ���� �ð��� �ʰ��Ǹ�
            {
                if (score >= 20)
                {
                    GameClear(); // ���ھ 20 �̻��̸� ���� Ŭ����
                    Destroy(gameObject); // ���� �Ŵ��� �ı�
                }
                else
                {
                    GameOver(); // �ƴϸ� ���� ����
                    Destroy(gameObject); // ���� �Ŵ��� �ı�
                }
            }
        }
    }

    public void AddScore(int value)
    {
        score += value; // ���ھ� ����
        UpdateScoreUI(); // UI ������Ʈ
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // ���ھ� �ؽ�Ʈ ������Ʈ
        }
    }

    public void IncreaseScore(int points)
    {
        score += points; // ���ھ� ����
        OnScoreChanged.Invoke(score); // �̺�Ʈ ȣ��
    }

    public int GetScore()
    {
        return score; // ���� ���ھ� ��ȯ
    }

    private void GameOver()
    {
        isGameOver = true; // ���� ���� ���·� ����
        SceneManager.LoadScene("GameOverScene"); // ���� ���� ������ ��ȯ
        Destroy(gameObject); // ���� �Ŵ��� �ı�
    }

    private void GameClear()
    {
        isGameOver = true; // ���� Ŭ���� ���·� ����
        SceneManager.LoadScene("BossScene2"); // ���� ������ ��ȯ
        Destroy(gameObject); // ���� �Ŵ��� �ı�
    }
}
