using UnityEngine;

public class ObjShot : MonoBehaviour
{
    public GameObject playerMissilePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스 바를 누를 시 미사일 발사
        {
            GameObject missile = Instantiate(playerMissilePrefab, transform.position, transform.rotation);
        }
    }
}
