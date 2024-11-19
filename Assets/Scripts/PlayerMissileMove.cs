using UnityEngine;

public class PlayerMissileMove : MonoBehaviour
{
    public float speed = 5f; // 미사일의 속도
    public int damage = 10; // 미사일의 데미지

    void Update()
    {
        // 미사일을 오른쪽으로 이동
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적 미사일이나 보스 미사일과 충돌했을 시
        if (collision.CompareTag("EnemyMissile") || collision.CompareTag("BossMissile"))
        {
            // 적 미사일과 충돌했을 때 자신을 파괴
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            //충돌한 오브젝트의 태그가 적인경우
            EnemyManager enemyManager = collision.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                //적에게 데미지를 입힘
                enemyManager.TakeDamage(damage);
                int enemyHealth = enemyManager.GetHealth(); // 적의 현재 체력을 가져옴
                Debug.Log("적의 체력: " + enemyHealth);
            }
            Destroy(gameObject); // 적에게 충돌했을 때 미사일 파괴
        }
    }


}