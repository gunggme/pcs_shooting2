using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    float curDelay = 0;
    float maxDelay = 0.1f;
    //총알 생성할 공장
    //4.총알공장에서 총알 생성
    public GameObject bulletFactory;

    // 목표 : 총알 오브젝트 풀을 만들어 관리하고 싶다.
    //필요속성 : 탄창에 넣을 수 있는 총알의 개수, 오브젝트룰 생성
    //탄창에 넣을 수 있는 총알의 개수
    public int poolsize = 10;
    //오브젝트 풀 배열
    //GameObject[] bulletObjectPool;
    public List<GameObject> bulletObjectPool;

    //태어날 때
    private void Start()
    {
        //2. 탄창을 만들어 준다
        bulletObjectPool = new List<GameObject>();
        //3. 탄창의 총알 개수만 큼 반복
        for(int i = 0; i < poolsize; i++)
        {
            //4.총알공장에서 총알 생성
            GameObject bullet = Instantiate(bulletFactory);

            // 5. 총알을 오브젝트 풀에 넣고 싶다
            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Add(bullet);

            //비활성화 시키자
            bullet.SetActive(false);
        }

    }



    //총구
    
    public GameObject firePosition;
    
    //목표 : 발사 버튼을 누름ㅕㄴ 탄창에 있는 총알 중 비활성화 된 것을 발사하고 싶다.
    
    void Update()
    {
        //1. 발사 버튼을 눌렀으니깐
        curDelay += Time.deltaTime;

        if (curDelay > maxDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                //탄창 안에 총알이 있다면
                if(bulletObjectPool.Count < 0)
                {
                    //비활성화 된 
                    GameObject bullet = bulletObjectPool[0];
                    //총알을 발사하고 싶다.
                    bullet.SetActive(true);

                    bulletObjectPool.RemoveAt(0);

                    bullet.transform.position = transform.position;
                }
                curDelay = 0;
            }
        }
    }
}