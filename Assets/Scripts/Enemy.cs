using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;
    //폭발 공장 주소 만들기
    public GameObject explosionFactory;
    void Start()
    {
       
    }

    //객체가 활성화 될때 마다
    private void OnEnable()
    {
        //30% 확률로 player방향, 나머지는 아래로
        //0부터 9까지 10개의 값중에 하나를 랜텀으로 가져온다 
        int randomVelue = Random.Range(0, 10);
        //만약 3보다 작으면 플레이어 털?자
        if (randomVelue < 3)
        {
            //플레이어를 찾아서 target으로 한다.
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;

            //방향의 크기를 1로 하고싶다.
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        //방향 구하기
        transform.position += dir * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        //0. 적이 다른 물체오 충돌 했으니까
        //1. Scene에서 ScoreManager객체를 찾아오자


        //2. ScoreManager GameObject에서 Component를 가져온다



        //Score Manager에서 get과 set을 호출 하겠다
        ScoreManager.Instance.score++;
        //3. ScoreManager 클래스의 속성에 값을 할당한다.
        

        //폭발 효과 생성
        GameObject explosion = Instantiate(explosionFactory);
        //폭발 효과 위치 이동
        explosion.transform.position = transform.position;

        //만약 부딪힌 객체가 bullet일 경우에는 비 활성화 시켜 다시 재활성화 시킬 수 있게 하다.
        //1. 만약 부딪힌 물체가 bullet인 경우
        if (other.gameObject.name.Contains("Bullet"))
        {
            //2. 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
           
        }
        //그렇지 않으면
        else
        {
            Destroy(other.gameObject);
        }
        gameObject.SetActive(false);
    }
}