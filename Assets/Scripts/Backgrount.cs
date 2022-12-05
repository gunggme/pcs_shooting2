using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrount : MonoBehaviour
{
    //��� Material
    public Material bgMeterial;

    //��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;

    void Update()
    {
        //���� �ʿ�
        Vector2 direction = Vector2.up;

        //��ũ��
        bgMeterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
