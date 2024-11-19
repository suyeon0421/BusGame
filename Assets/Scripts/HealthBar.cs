using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // ü�� ��

    void Start()
    {
        // �÷��̾ �θ�� ����
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
    }

    // ���� ü�°� �ִ� ü���� �����ϴ� �޼���
    public void SetHealth(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth; //value = ���� ü��
        slider.maxValue = maxHealth; //maxValue = �ִ� ü��
    }
}
