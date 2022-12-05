using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enermy"))
        {
            //2. �ε��� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);
            //3. �ε��� ��ü�� �Ѿ��� ��� �Ѿ� ����Ʈ���� ����

            if (other.gameObject.name.Contains("Bullet"))
            {
                //playerFireŬ���� ��� ����
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                //����Ʈ�� �Ѿ� ����
                player.bulletObjectPool.Add(other.gameObject);
            }
        }
        
        
        
    }
}

