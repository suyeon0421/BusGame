using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Replay 버튼을 눌렀을 때 호출되는 메서드
    public void OnReplayButtonClick()
    {
        SceneManager.LoadScene("StageScene1");
    }

    // Home 버튼을 눌렀을 때 호출되는 메서드
    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
