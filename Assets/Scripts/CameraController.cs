using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private Vector2 playerSize;

    void Start()
    {
        mainCamera = Camera.main;
        playerSize = GetComponent<SpriteRenderer>().bounds.size; // 플레이어의 크기를 가져옴

        // 카메라 뷰포트 좌표를 월드 좌표로 변환함
        Vector3 lowerLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 upperRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // 플레이어가 화면 밖으로 나가지 않도록 제한함
        minX = lowerLeft.x + playerSize.x / 2;
        maxX = upperRight.x - playerSize.x / 2;
        minY = lowerLeft.y + playerSize.y / 2;
        maxY = upperRight.y - playerSize.y / 2;
    }

    void Update()
    {
        // 플레이어의 현재 위치를 가져옴
        Vector3 clampedPosition = transform.position;

        // X 좌표를 제한
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        // Y 좌표를 제한
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        // 제한된 위치로 플레이어를 이동
        transform.position = clampedPosition;
    }
}
