using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrount : MonoBehaviour
{
    //배경 Material
    public Material bgMeterial;

    //스크롤 속도
    public float scrollSpeed = 0.2f;

    void Update()
    {
        //방향 필요
        Vector2 direction = Vector2.up;

        //스크롤
        bgMeterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
