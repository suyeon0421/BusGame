using UnityEngine;

public class BossMissileMove2 : MonoBehaviour
{
    public float speed = 5f; // 미사일의 속도
    public int damage = 5; // 미사일의 데미지

    private Transform playerTransform; // 플레이어의 위치를 저장할 변수
    private BossManager2 bossManager; // 적의 정보를 받아오기 위한 변수

    void Start()
    {
        // 플레이어의 위치 찾기
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform == null)
        {
            // 플레이어가 없으면 미사일 삭제
            Destroy(gameObject);
            return;
        }

        // 플레이어 쪽으로 방향 설정
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        // 미사일을 플레이어 쪽으로 이동
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject); // 미사일 자신 파괴
        }

        if (collision.CompareTag("PlayerMissile"))
        {
            // 적 미사일과 충돌했을 때 자신을 파괴
            Destroy(gameObject);
        }
    }

}
