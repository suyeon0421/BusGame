using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyMissilePrefab; // 적의 미사일 프리팹
    public Transform target; // 플레이어의 위치

    public float moveSpeed = 3f; // 적의 이동 속도
    public float attackRange = 10f; // 공격 범위
    public float attackCooldown = 2f; // 공격 쿨다운
    private float attackTimer = 0f; // 공격 쿨다운 타이머
    public int health = 10;
    private int attackPower = 5; // 적의 공격력
    public Player player; // 플레이어



    void Update()
    {
        if (target == null)
            return;

        // 적의 이동 로직
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 적이 플레이어와 일정 거리 안에 있고 공격 쿨다운이 완료되었을 때 미사일 발사
        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer <= 0f)
        {
            FireMissile();
            attackTimer = attackCooldown;
        }

        attackTimer -= Time.deltaTime;
    }

    void FireMissile()
    {
        // 적의 위치에서 플레이어를 향하는 방향 벡터 계산
        Vector3 direction = (target.position - transform.position).normalized;

        // 미사일 발사
        GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<EnemyMissileMove>().damage = attackPower; // 미사일에 공격력 설정
    }

    public int GetHealth()
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
        }
    }

    // 적이 죽었을 때의 처리
    private void Die()
    {
        player.IncreaseAttackPower(); // 플레이어의 공격력 증가
        // 적이 죽었을 때의 로직을 작성합니다.
        Destroy(gameObject); // 적 오브젝트 파괴 예시
    }
}
