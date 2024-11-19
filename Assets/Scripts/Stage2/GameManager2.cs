using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance; // 게임 매니저의 인스턴스

    private int score = 0; // 현재 스코어
    public Text scoreText; // UI에 표시할 스코어 텍스트
    public float gameTime = 30f; // 게임 시간 (초)
    private float timer = 0f; // 현재 경과된 시간
    private bool isGameOver = false; // 게임 종료 여부

    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>(); // 스코어 변경 이벤트

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // 인스턴스가 없으면 자신을 설정
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 이미 인스턴스가 있으면 자신을 파괴
        }
    }

    private void Start()
    {
        timer = gameTime; // 타이머 초기화
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime; // 타이머 감소

            if (timer <= 0) // 게임 시간이 초과되면
            {
                if (score >= 20)
                {
                    GameClear(); // 스코어가 20 이상이면 게임 클리어
                    Destroy(gameObject); // 게임 매니저 파괴
                }
                else
                {
                    GameOver(); // 아니면 게임 오버
                    Destroy(gameObject); // 게임 매니저 파괴
                }
            }
        }
    }

    public void AddScore(int value)
    {
        score += value; // 스코어 증가
        UpdateScoreUI(); // UI 업데이트
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // 스코어 텍스트 업데이트
        }
    }

    public void IncreaseScore(int points)
    {
        score += points; // 스코어 증가
        OnScoreChanged.Invoke(score); // 이벤트 호출
    }

    public int GetScore()
    {
        return score; // 현재 스코어 반환
    }

    private void GameOver()
    {
        isGameOver = true; // 게임 오버 상태로 설정
        SceneManager.LoadScene("GameOverScene"); // 게임 오버 씬으로 전환
        Destroy(gameObject); // 게임 매니저 파괴
    }

    private void GameClear()
    {
        isGameOver = true; // 게임 클리어 상태로 설정
        SceneManager.LoadScene("BossScene2"); // 보스 씬으로 전환
        Destroy(gameObject); // 게임 매니저 파괴
    }
}
