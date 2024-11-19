using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public AudioSource audioSource; // 효과음을 재생할 AudioSource 컴포넌트

    void Update()
    {
        // 스페이스바가 눌리면 효과음 재생
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource != null)
            {
                audioSource.Play(); // AudioSource에서 지정한 오디오 클립 재생
            }
        }
    }
}
