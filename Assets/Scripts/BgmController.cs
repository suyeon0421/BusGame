using UnityEngine;

public class BgmController : MonoBehaviour
{
    private AudioSource bgmSource;

    void Awake()
    {
        //AudioSource 컴포넌트 가져와서 변수에 할당
        bgmSource = GetComponent<AudioSource>();
    }

    public void PlayBGM() //배경음악 재생
    {
        if (bgmSource != null)
        {
            bgmSource.Play();
        }
    }

    public void StopBGM() //베경음악 정지
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }
}
