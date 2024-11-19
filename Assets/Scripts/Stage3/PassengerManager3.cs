using UnityEngine;

public class PassengerManager3 : MonoBehaviour
{
    public int scoreValue = 1;  //���̾��Ű â���� scoreValue ���� ����, ����� �°����� -5�� ����

    private bool collected = false; //�����Ǿ����� Ȯ���ϴ� ����

    private void Start()
    {
        collected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player")) //���� �������� �ʾҰ�, �±װ� Player�� �Ǿ��ִ� ������Ʈ�� �浹 ��
        {
            GameManager3.instance.AddScore(scoreValue); //GameManager�� Addscore �޼ҵ� ȣ���Ͽ� ���� ����

            gameObject.SetActive(false); //�°� ������Ʈ ��Ȱ��ȭ

            collected = true;
        }
    }
}
