using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyMissilePrefab; // ���� �̻��� ������
    public Transform target; // �÷��̾��� ��ġ

    public float moveSpeed = 3f; // ���� �̵� �ӵ�
    public float attackRange = 10f; // ���� ����
    public float attackCooldown = 2f; // ���� ��ٿ�
    private float attackTimer = 0f; // ���� ��ٿ� Ÿ�̸�
    public int health = 10;
    private int attackPower = 5; // ���� ���ݷ�
    public Player player; // �÷��̾�



    void Update()
    {
        if (target == null)
            return;

        // ���� �̵� ����
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // ���� �÷��̾�� ���� �Ÿ� �ȿ� �ְ� ���� ��ٿ��� �Ϸ�Ǿ��� �� �̻��� �߻�
        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer <= 0f)
        {
            FireMissile();
            attackTimer = attackCooldown;
        }

        attackTimer -= Time.deltaTime;
    }

    void FireMissile()
    {
        // ���� ��ġ���� �÷��̾ ���ϴ� ���� ���� ���
        Vector3 direction = (target.position - transform.position).normalized;

        // �̻��� �߻�
        GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<EnemyMissileMove>().damage = attackPower; // �̻��Ͽ� ���ݷ� ����
    }

    public int GetHealth()
    {
        return health;
    }

    // ������ ���ظ� ������ �޼���
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // ���� �׾��� ���� ó��
        }
    }

    // ���� �׾��� ���� ó��
    private void Die()
    {
        player.IncreaseAttackPower(); // �÷��̾��� ���ݷ� ����
        // ���� �׾��� ���� ������ �ۼ��մϴ�.
        Destroy(gameObject); // �� ������Ʈ �ı� ����
    }
}
