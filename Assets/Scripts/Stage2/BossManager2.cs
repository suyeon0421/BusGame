using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager2 : MonoBehaviour
{
    public GameObject enemyMissilePrefab; // ���� �̻��� ������
    public Transform target; // �÷��̾��� ��ġ

    public float moveSpeed = 3f; // ���� �̵� �ӵ�
    public float attackRange = 10f; // ���� ����
    public float attackCooldown = 2f; // ���� ��ٿ�
    private float attackTimer = 0f; // ���� ��ٿ� Ÿ�̸�
    public int health = 100; // ������ ü��
    private int attackPower = 10; // ���� ���ݷ�
    public Player player; // �÷��̾�

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
