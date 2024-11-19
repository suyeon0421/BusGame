using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager2 : MonoBehaviour
{
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
        if (target == null)
            return;

        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer <= 0f)
        {
            FireMissile();
            attackTimer = attackCooldown;
        }

        attackTimer -= Time.deltaTime;
    }

    void FireMissile()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<BossMissileMove2>().damage = attackPower; 
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); 
            SceneManager.LoadScene("StageScene3");
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        player.IncreaseAttackPower(); 
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerMissile"))
        {
            PlayerMissileMove missile = collision.GetComponent<PlayerMissileMove>();
            if (missile != null)
            {
                TakeDamage(player.attackPower);
                Destroy(collision.gameObject); 
            }
        }
    }
}
