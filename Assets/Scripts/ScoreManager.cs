using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    //�̱��� ��ü
    public static ScoreManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    //get set ������Ƽ
    public int score { 
    get
        {
            return currentScore;
        }
        set
        {
            currentScore++;

            //4. ȭ�鿡 ���� ��ȭ
            currentScoreUI.text = "�������� : " + currentScore.ToString("D8");

            //��ǥ : �ְ� ������ ǥ���ϰ� �ʹ�.
            //1��. ���� ������ �ְ��������� ũ�ϱ�
            //���� ���������� �ְ� ������ �ʰ� �Ͽ��ٸ�.
            if (currentScore > bestScore)
            {
                //2. �ְ������� ���� ��Ų��.
                bestScore = currentScore;
                //3. �ְ������� UI�� ǥ��
                bestScoreUI.text = "�ְ����� : " + bestScore;
                //4. �ְ������� �����ϰ� �ʹ�.
                PlayerPrefs.SetFloat("Best", bestScore);

            }
        }
    }

    //�������� UI;
    public Text currentScoreUI;
    //��������
    //�ν����� â���� ������
    [System.NonSerialized] // = HideInInspector
    private int currentScore;

    //��ǥ : �ְ������� ǥ���ϰ� �ʹ�.
    //�ʿ� �Ӽ� : �ְ�����UI, �ְ����� ���
    //�ְ�����UI
    public Text bestScoreUI;
    //�ְ�����
    private float bestScore;


    //���� ������ ��ġ�� �������� ũ�ϱ�
    //�ְ������� ���� ��Ų��.
    //�ְ� ���� UI�� ǥ��

    //��ǥ : �ְ������� �ҷ��� bestScore ������ �Ҵ��ϰ� �ҷ����� �ʹ�
    //���� : �ְ������� �ҷ��� bestScore�� �ٿ��ֱ�
    // �ְ������� ȭ�鿡 ǥ���ϱ�.
    private void Start()
    {
        //���� 1 : �ְ������� �ҷ��� bestScore�� �ҷ�����
        bestScore = PlayerPrefs.GetFloat("Best");
        bestScoreUI.text = "�ְ�����  : " + bestScore;
    }


    //currentScore�� ���� �ְ� 
    public void SetScore(int value)
    {
        
    }

    public int GetScore()
    {
        return currentScore;
    }
}