using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;
    //���� ���� �ּ� �����
    public GameObject explosionFactory;
    void Start()
    {
       
    }

    //��ü�� Ȱ��ȭ �ɶ� ����
    private void OnEnable()
    {
        //30% Ȯ���� player����, �������� �Ʒ���
        //0���� 9���� 10���� ���߿� �ϳ��� �������� �����´� 
        int randomVelue = Random.Range(0, 10);
        //���� 3���� ������ �÷��̾� ��?��
        if (randomVelue < 3)
        {
            //�÷��̾ ã�Ƽ� target���� �Ѵ�.
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;

            //������ ũ�⸦ 1�� �ϰ�ʹ�.
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        //���� ���ϱ�
        transform.position += dir * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        //0. ���� �ٸ� ��ü�� �浹 �����ϱ�
        //1. Scene���� ScoreManager��ü�� ã�ƿ���


        //2. ScoreManager GameObject���� Component�� �����´�



        //Score Manager���� get�� set�� ȣ�� �ϰڴ�
        ScoreManager.Instance.score++;
        //3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        

        //���� ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);
        //���� ȿ�� ��ġ �̵�
        explosion.transform.position = transform.position;

        //���� �ε��� ��ü�� bullet�� ��쿡�� �� Ȱ��ȭ ���� �ٽ� ��Ȱ��ȭ ��ų �� �ְ� �ϴ�.
        //1. ���� �ε��� ��ü�� bullet�� ���
        if (other.gameObject.name.Contains("Bullet"))
        {
            //2. �ε��� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);
           
        }
        //�׷��� ������
        else
        {
            Destroy(other.gameObject);
        }
        gameObject.SetActive(false);
    }
}