using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 curPos = transform.position; //현재 위치 저장
        Vector3 nextPos = Vector3.left * speed * Time.deltaTime; //다음 위치 계산
        transform.position = curPos + nextPos; //현재 위치와 다음 위치를 더하여 이동함
    }
}
