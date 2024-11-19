using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Replay ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnReplayButtonClick()
    {
        SceneManager.LoadScene("StageScene1");
    }

    // Home ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
