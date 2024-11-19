using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public AudioSource audioSource; // ȿ������ ����� AudioSource ������Ʈ

    void Update()
    {
        // �����̽��ٰ� ������ ȿ���� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource != null)
            {
                audioSource.Play(); // AudioSource���� ������ ����� Ŭ�� ���
            }
        }
    }
}
