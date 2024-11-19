using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 curPos = transform.position; //���� ��ġ ����
        Vector3 nextPos = Vector3.left * speed * Time.deltaTime; //���� ��ġ ���
        transform.position = curPos + nextPos; //���� ��ġ�� ���� ��ġ�� ���Ͽ� �̵���
    }
}
