using UnityEngine;
using UnityEngine.UI;

public class PageSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class PageInfo
    {
        public string text;    // �������� �ؽ�Ʈ
        public int fontSize;   // �������� ���� ũ��
    }

    public Text descriptionText; // UI Text ������Ʈ
    public PageInfo[] pages;     // ���� ������ �迭
    private int currentPage = 0;

    void Start()
    {
        // ù ��° �������� ǥ��
        DisplayPage();
    }

    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            NextPage();
        }
    }

    void DisplayPage()
    {
        // ���� �������� �ؽ�Ʈ�� ���� ũ�⸦ UI�� ǥ��
        descriptionText.text = pages[currentPage].text;
        descriptionText.fontSize = pages[currentPage].fontSize;
    }

    void NextPage()
    {
        // ���� �������� ��ȯ
        currentPage++;
        if (currentPage < pages.Length)
        {
            DisplayPage();
        }
        else
        {
            // ��� �������� �� ������ StageScene1���� ��ȯ
            UnityEngine.SceneManagement.SceneManager.LoadScene("StageScene1");
        }
    }
}
