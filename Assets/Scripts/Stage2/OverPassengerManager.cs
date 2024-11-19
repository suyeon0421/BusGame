using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가

public class OverPassengerManager : MonoBehaviour
{
    public int scoreValue = 1;  // 하이어라키 창에서 scoreValue 수정 가능, 노란색 승객에는 -5로 설정

    private bool collected = false; // 수집되었는지 확인하는 변수

    private void Start()
    {
        collected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player")) // 아직 수집되지 않았고, 태그가 Player로 되어있는 오브젝트와 충돌 시
        {
            // 게임 오버 씬으로 전환
            SceneManager.LoadScene("GameOverScene");

            collected = true;
        }
    }
}
