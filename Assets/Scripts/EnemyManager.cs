using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ : ���ʹ� ������Ʈ Ǯ�� ����� �����ϰ� �ʹ�.
//�ʿ� �Ӽ� : ������Ʈ Ǯ ũ�⸦ ���ϰ� ������Ʈ Ǯ �迭, SpawnPoint�� 

public class EnemyManager : MonoBehaviour
{
    //�����ð����� ���� ������ EnemyManager��ġ�� �� �̵�
    //�����ð� == �����ð�(����ð�, �� ������ �ʿ�)
    //1. �ð��� �帣�� 2. ���� �ð��� �����ð��� �Ǹ� 3. �� ���� 4. EnemyManager��ġ�� �̵�





    //������Ʈ Ǯ ũ��
    public int poolSize = 10;
    //dhqmwprxm vnf qoduf
    GameObject[] enermyObjectPool;
    //���� ����Ʈ
    public Transform[] spawnPoints;




    //����ð�
    float currentTime;
    //�����ð�
    public float createTime;
    //�� ������
    public GameObject enemyFactory;

    //�� ���� �ð��� �������� �ϰ�;� ���󿡸� �ּҽð��� �ִ�ð�

    //�ּҽð�
    float minTime = 0.5f;
    //�ִ� �ð�
    float maxTime = 2.5f;
    
    //�¾��
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);    
        //2. ������Ʈ Ǯ�� ���ʹ̵��� ���� �� �ִ� ũ��� ����� �ش�
        enermyObjectPool= new GameObject[poolSize];

        //3, ������Ʈ ���� ���� ���ʹ� ���� ������ ���ؼ�
        for(int i = 0; i < poolSize; i++)
        {
            //4. ���ʹ� ���忡�� ���ʹ̸� �����Ѵ�.
            GameObject enermy = Instantiate(enemyFactory);
            //5. ���ʹ̸� ������Ʈ Ǯ�� �ְ� �ʹ�
            enermyObjectPool[i] = enermy;
            //��Ȱ��ȭ ��Ű��
            enermy.SetActive(false);
        }

    }
    void Update()
    {
        //�ð��� �帧
        currentTime += Time.deltaTime;
        //���� ����ð��� �����ð��� �Ǹ�
        if(currentTime > createTime)
        {
            for (int i = 0; i < poolSize; i++)
            {
                //��Ȱ��ȭ �� ���ʹ̸�
                GameObject enermy = enermyObjectPool[i];
                if (enermy.activeSelf == false)
                {
                    //���ʹ̸� Ȱ��ȭ �ϰ� �ʹ�
                    enermy.SetActive(true);

                    //�������� �ε��� ����
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