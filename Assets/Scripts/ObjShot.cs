using UnityEngine;

public class ObjShot : MonoBehaviour
{
    public GameObject playerMissilePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �����̽� �ٸ� ���� �� �̻��� �߻�
        {
            GameObject missile = Instantiate(playerMissilePrefab, transform.position, transform.rotation);
        }
    }
}
