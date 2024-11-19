using UnityEngine;

public class PassengerManager3 : MonoBehaviour
{
    public int scoreValue = 1;  //하이어라키 창에서 scoreValue 수정 가능, 노란색 승객에는 -5로 설정

    private bool collected = false; //수집되었는지 확인하는 변수

    private void Start()
    {
        collected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player")) //아직 수집되지 않았고, 태그가 Player로 되어있는 오브젝트와 충돌 시
        {
            GameManager3.instance.AddScore(scoreValue); //GameManager의 Addscore 메소드 호출하여 점수 증가

            gameObject.SetActive(false); //승객 오브젝트 비활성화

            collected = true;
        }
    }
}
