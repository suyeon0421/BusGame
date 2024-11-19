using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private Vector2 playerSize;

    void Start()
    {
        mainCamera = Camera.main;
        playerSize = GetComponent<SpriteRenderer>().bounds.size; // �÷��̾��� ũ�⸦ ������

        // ī�޶� ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ��
        Vector3 lowerLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 upperRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // �÷��̾ ȭ�� ������ ������ �ʵ��� ������
        minX = lowerLeft.x + playerSize.x / 2;
        maxX = upperRight.x - playerSize.x / 2;
        minY = lowerLeft.y + playerSize.y / 2;
        maxY = upperRight.y - playerSize.y / 2;
    }

    void Update()
    {
        // �÷��̾��� ���� ��ġ�� ������
        Vector3 clampedPosition = transform.position;

        // X ��ǥ�� ����
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        // Y ��ǥ�� ����
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        // ���ѵ� ��ġ�� �÷��̾ �̵�
        transform.position = clampedPosition;
    }
}
