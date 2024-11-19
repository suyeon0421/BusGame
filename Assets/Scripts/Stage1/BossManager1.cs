using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager1 : MonoBehaviour
{
    //BossManager1, 2, 3�� �� �̵� �ڵ常 �ٸ��Ŷ� BossManger1���� �ּ� �ۼ��ϰڽ��ϴ�.

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
        //�÷��̾ ���ٸ� ����
        if (target == null)
            return;

        // ���� �÷��̾�� ���� �Ÿ� �ȿ� �ְ� ���� ��ٿ��� �Ϸ�Ǿ��� �� �̻��� �߻�
        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackTimer <= 0f)
        {
            FireMissile();
            attackTimer = attackCooldown; //��Ÿ�� ����
        }

        attackTimer -= Time.deltaTime;
    }

    void FireMissile()
    {
        // ���� ��ġ���� �÷��̾ ���ϴ� ���� ���� ���
        Vector3 direction = (target.position - transform.position).normalized;

        // �̻��� �߻�
        GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<BossMissileMove1>().damage = attackPower; // �̻��Ͽ� ���ݷ� ����
    }

    public int GetHealth() //������ ���� ü�� ��ȯ
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
            SceneManager.LoadScene("StageScene2");
            Destroy(gameObject); // ���� �Ŵ��� �ı�
        }
    }

    // ���� �׾��� ���� ó��
    private void Die()
    {
        player.IncreaseAttackPower(); // �÷��̾��� ���ݷ� ����
        Destroy(gameObject); // �� ������Ʈ �ı� ����
    }

    // ������ �÷��̾��� �̻��Ͽ� �¾��� �� �������� �Դ� �޼���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerMissile"))
        {
            PlayerMissileMove missile = collision.GetComponent<PlayerMissileMove>();
            if (missile != null)
            {
                TakeDamage(player.attackPower); //�÷��̾��� ���ݷ� ��ŭ ���ظ� ����
                Destroy(collision.gameObject); // �÷��̾��� �̻��� �ı�
            }
        }
    }
}
