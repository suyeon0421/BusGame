using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // 체력 바

    void Start()
    {
        // 플레이어를 부모로 설정
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
    }

    // 현재 체력과 최대 체력을 설정하는 메서드
    public void SetHealth(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth; //value = 현재 체력
        slider.maxValue = maxHealth; //maxValue = 최대 체력
    }
}
