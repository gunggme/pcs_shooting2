using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    float curDelay = 0;
    float maxDelay = 0.1f;
    //�Ѿ� ������ ����
    //4.�Ѿ˰��忡�� �Ѿ� ����
    public GameObject bulletFactory;

    // ��ǥ : �Ѿ� ������Ʈ Ǯ�� ����� �����ϰ� �ʹ�.
    //�ʿ�Ӽ� : źâ�� ���� �� �ִ� �Ѿ��� ����, ������Ʈ�� ����
    //źâ�� ���� �� �ִ� �Ѿ��� ����
    public int poolsize = 10;
    //������Ʈ Ǯ �迭
    //GameObject[] bulletObjectPool;
    public List<GameObject> bulletObjectPool;

    //�¾ ��
    private void Start()
    {
        //2. źâ�� ����� �ش�
        bulletObjectPool = new List<GameObject>();
        //3. źâ�� �Ѿ� ������ ŭ �ݺ�
        for(int i = 0; i < poolsize; i++)
        {
            //4.�Ѿ˰��忡�� �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);

            // 5. �Ѿ��� ������Ʈ Ǯ�� �ְ� �ʹ�
            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Add(bullet);

            //��Ȱ��ȭ ��Ű��
            bullet.SetActive(false);
        }

    }



    //�ѱ�
    
    public GameObject firePosition;
    
    //��ǥ : �߻� ��ư�� �����Ť� źâ�� �ִ� �Ѿ� �� ��Ȱ��ȭ �� ���� �߻��ϰ� �ʹ�.
    
    void Update()
    {
        //1. �߻� ��ư�� �������ϱ�
        curDelay += Time.deltaTime;

        if (curDelay > maxDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                //źâ �ȿ� �Ѿ��� �ִٸ�
                if(bulletObjectPool.Count < 0)
                {
                    //��Ȱ��ȭ �� 
                    GameObject bullet = bulletObjectPool[0];
                    //�Ѿ��� �߻��ϰ� �ʹ�.
                    bullet.SetActive(true);

                    bulletObjectPool.RemoveAt(0);

                    bullet.transform.position = transform.position;
                }
                curDelay = 0;
            }
        }
    }
}