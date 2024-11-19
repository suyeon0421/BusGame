using UnityEngine;
using UnityEngine.UI;

public class PageSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class PageInfo
    {
        public string text;    // 페이지의 텍스트
        public int fontSize;   // 페이지의 글자 크기
    }

    public Text descriptionText; // UI Text 오브젝트
    public PageInfo[] pages;     // 설명 페이지 배열
    private int currentPage = 0;

    void Start()
    {
        // 첫 번째 페이지를 표시
        DisplayPage();
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            NextPage();
        }
    }

    void DisplayPage()
    {
        // 현재 페이지의 텍스트와 글자 크기를 UI에 표시
        descriptionText.text = pages[currentPage].text;
        descriptionText.fontSize = pages[currentPage].fontSize;
    }

    void NextPage()
    {
        // 다음 페이지로 전환
        currentPage++;
        if (currentPage < pages.Length)
        {
            DisplayPage();
        }
        else
        {
            // 모든 페이지를 다 봤으면 StageScene1으로 전환
            UnityEngine.SceneManagement.SceneManager.LoadScene("StageScene1");
        }
    }
}
