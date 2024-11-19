using UnityEngine;

public class BgmController : MonoBehaviour
{
    private AudioSource bgmSource;

    void Awake()
    {
        //AudioSource ������Ʈ �����ͼ� ������ �Ҵ�
        bgmSource = GetComponent<AudioSource>();
    }

    public void PlayBGM() //������� ���
    {
        if (bgmSource != null)
        {
            bgmSource.Play();
        }
    }

    public void StopBGM() //�������� ����
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }
}
