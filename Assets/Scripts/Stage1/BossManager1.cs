using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager1 : MonoBehaviour
{
    //BossManager1, 2, 3은 씬 이동 코드만 다른거라서 BossManger1에만 주석 작성하겠습니다.

    public GameObject enemyMissilePrefab; // 적의 미사일 프리팹
    public Transform target; // 플레이어의 위치

    public float moveSpeed = 3f; // 적의 이동 속도
    public float attackRange = 10f; // 공격 범위
    public float attackCooldown = 2f; // 공격 쿨다운
    private float attackTimer = 0f; // 공격 쿨다운 타이머
    public int health = 100; // 보스의 체력
    private int attackPower = 10; // 적의 공격력
    public Player player; // 플레이어

    void Update()
    {
        //플레이어가 없다면 종료
        if (target == null)
            return;

        // 적이 플레이어와 일정 거리 안에 있고 공격 쿨다운이 완료되었을 때 미사일 발사
        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer <= 0f)
        {
            FireMissile();
            attackTimer = attackCooldown; //쿨타임 설정
        }

        attackTimer -= Time.deltaTime;
    }

    void FireMissile()
    {
        // 적의 위치에서 플레이어를 향하는 방향 벡터 계산
        Vector3 direction = (target.position - transform.position).normalized;

        // 미사일 발사
        GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<BossMissileMove1>().damage = attackPower; // 미사일에 공격력 설정
    }

    public int GetHealth() //보스의 현재 체력 반환
    {
        return health;
    }

    // 적에게 피해를 입히는 메서드
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // 적이 죽었을 때의 처리
            SceneManager.LoadScene("StageScene2");
            Destroy(gameObject); // 게임 매니저 파괴
        }
    }

    // 적이 죽었을 때의 처리
    private void Die()
    {
        player.IncreaseAttackPower(); // 플레이어의 공격력 증가
        Destroy(gameObject); // 적 오브젝트 파괴 예시
    }

    // 보스가 플레이어의 미사일에 맞았을 때 데미지를 입는 메서드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerMissile"))
        {
            PlayerMissileMove missile = collision.GetComponent<PlayerMissileMove>();
            if (missile != null)
            {
                TakeDamage(player.attackPower); //플레이어의 공격력 만큼 피해를 입음
                Destroy(collision.gameObject); // 플레이어의 미사일 파괴
            }
        }
    }
}
