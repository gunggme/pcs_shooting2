using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enermy"))
        {
            //2. 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
            //3. 부딪힌 물체가 총알일 경우 총알 리스트에서 삭제

            if (other.gameObject.name.Contains("Bullet"))
            {
                //playerFire클래스 얻어 오기
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                //리스트에 총알 삽입
                player.bulletObjectPool.Add(other.gameObject);
            }
        }
        
        
        
    }
}

