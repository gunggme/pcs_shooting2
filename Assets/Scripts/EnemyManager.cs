using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 에너미 오브젝트 풀을 만들어 관리하고 싶다.
//필요 속성 : 오브젝트 풀 크기를 정하고 오브젝트 풀 배열, SpawnPoint를 

public class EnemyManager : MonoBehaviour
{
    //일정시간마다 적을 생성후 EnemyManager위치로 적 이동
    //일정시간 == 생성시간(현재시간, 적 프리펩 필요)
    //1. 시간이 흐르고 2. 현재 시간이 일정시간이 되면 3. 적 생성 4. EnemyManager위치로 이동





    //오브젝트 풀 크기
    public int poolSize = 10;
    //dhqmwprxm vnf qoduf
    GameObject[] enermyObjectPool;
    //스폰 포인트
    public Transform[] spawnPoints;




    //현재시간
    float currentTime;
    //생성시간
    public float createTime;
    //적 프리펩
    public GameObject enemyFactory;

    //적 생성 시간을 랜덤으로 하고싶어 도라에몽 최소시간과 최대시간

    //최소시간
    float minTime = 0.5f;
    //최대 시간
    float maxTime = 2.5f;
    
    //태어날때
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);    
        //2. 오브젝트 풀을 에너미들을 담을 수 있는 크기로 만들어 준다
        enermyObjectPool= new GameObject[poolSize];

        //3, 오브젝트 폴에 넣을 에너미 개수 변겅을 위해서
        for(int i = 0; i < poolSize; i++)
        {
            //4. 에너미 공장에서 에너미를 등장한다.
            GameObject enermy = Instantiate(enemyFactory);
            //5. 에너미를 오브젝트 풀에 넣고 싶다
            enermyObjectPool[i] = enermy;
            //비활성화 시키자
            enermy.SetActive(false);
        }

    }
    void Update()
    {
        //시간이 흐름
        currentTime += Time.deltaTime;
        //만약 현재시간이 생성시간이 되면
        if(currentTime > createTime)
        {
            for (int i = 0; i < poolSize; i++)
            {
                //비활성화 된 에너미를
                GameObject enermy = enermyObjectPool[i];
                if (enermy.activeSelf == false)
                {
                    //에너미를 활성화 하고 싶다
                    enermy.SetActive(true);

                    //랜덤으로 인덱스 선택
                    int index = Random.Range(0, spawnPoints.Length);
                    
                    enermy.transform.position = spawnPoints[index].position;
                    break;
                }
            }

            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}