using UnityEngine;

public class PlayerMissileMove : MonoBehaviour
{
    public float speed = 5f; // �̻����� �ӵ�
    public int damage = 10; // �̻����� ������

    void Update()
    {
        // �̻����� ���������� �̵�
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�� �̻����̳� ���� �̻��ϰ� �浹���� ��
        if (collision.CompareTag("EnemyMissile") || collision.CompareTag("BossMissile"))
        {
            // �� �̻��ϰ� �浹���� �� �ڽ��� �ı�
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            //�浹�� ������Ʈ�� �±װ� ���ΰ��
            EnemyManager enemyManager = collision.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                //������ �������� ����
                enemyManager.TakeDamage(damage);
                int enemyHealth = enemyManager.GetHealth(); // ���� ���� ü���� ������
                Debug.Log("���� ü��: " + enemyHealth);
            }
            Destroy(gameObject); // ������ �浹���� �� �̻��� �ı�
        }
    }


}