using UnityEngine;

public class BossMissileMove2 : MonoBehaviour
{
    public float speed = 5f; // �̻����� �ӵ�
    public int damage = 5; // �̻����� ������

    private Transform playerTransform; // �÷��̾��� ��ġ�� ������ ����
    private BossManager2 bossManager; // ���� ������ �޾ƿ��� ���� ����

    void Start()
    {
        // �÷��̾��� ��ġ ã��
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform == null)
        {
            // �÷��̾ ������ �̻��� ����
            Destroy(gameObject);
            return;
        }

        // �÷��̾� ������ ���� ����
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        // �̻����� �÷��̾� ������ �̵�
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
            Destroy(gameObject); // �̻��� �ڽ� �ı�
        }

        if (collision.CompareTag("PlayerMissile"))
        {
            // �� �̻��ϰ� �浹���� �� �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

}
