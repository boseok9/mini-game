using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private GameObject Star; // Star object
    [SerializeField] private GameObject starCatch; // ������ ��� meteo Star�� ����.

    public float Speed = 5.0f;
    public float Bombfull = 100.0f;
    public float BombPoint = 0.0f;
    public float Combo = 0.0f;
    public bool FeverOn = false;
    public float FullTime = 60.0f;
    public float PlayTime = 60.0f;
    public int Score = 0;


    public static GamePlay instance = null;

    public List<GameObject[]> LiveMetor = new List<GameObject[]>(); // �ʿ� �����ϴ� ���׿��� ����.
    public List<GameObject[]> LiveStar = new List<GameObject[]>();

    void Awake() // start���� �� ���� ����
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Faster() { 
        if (Input.GetKeyDown(KeyCode.Space)) { 
       
            Speed += 0.5f;
            if (Speed >= 10.0f) Speed = 10.0f;
        }

    }

    private void BombFull()
    {
        PlayTime += 10.0f;
        BombPoint = 0.0f;
    }


    private void FeverTimeStart()
    {
        StartCoroutine("FeverTime");
    }


    IEnumerator FeverTime()   // ���� �޺� ������ ����, �ǹ�Ÿ��(�ε��� ����)
    {
        FeverOn = true;
        Debug.Log("Fever Time Start");
        Player player = FindObjectOfType<Player>();
        Speed = 20.0f;
        player.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(7.0f);

        FeverOn = false;
        Speed = 5.0f;

        player.GetComponent<BoxCollider2D>().isTrigger = true;
        Debug.Log("Fever Time End");
    }

    private void CheckTheLine()
    {
        if (LiveMetor.Count > 0)
        {
            var metor = LiveMetor[0];
            if (metor[0].transform.position.y <= -3)
            {
                Destroy(metor[0]);
                Destroy(metor[1]);
                LiveMetor.RemoveAt(0);
                BombPoint += 1.0f;
                GamePlay.instance.Combo += 1.0f;
                Score += 1;
            }
        }
        if (LiveStar.Count > 0)
        {
            var star = LiveStar[0];
            if (star[0].transform.position.y <= -3)
            {
                Destroy(star[0]);
                Destroy(star[1]);
                LiveStar.RemoveAt(0);
                BombPoint += 1.0f;
                GamePlay.instance.Combo += 1.0f;
            }
        }
    }

    public void BecomeStar() // �ʵ忡 �ִ� metoe -> star ��ȯ
    {
        for(int i=0; i<LiveMetor.Count; i++)
        {
            GameObject[] Stars = new GameObject[2];
            for (int j=0; j<2; j++)
            {   // Star ����
                Stars[0] = Instantiate(Star, LiveMetor[i][j].transform.position, Quaternion.identity);
                Stars[1] = Instantiate(Star, LiveMetor[i][j].transform.position, Quaternion.identity);
                Destroy(LiveMetor[i][j]);
            }
            LiveStar.Add(Stars);
        }
        LiveMetor.Clear();
    } 

    

    // Update is called once per frame
    void Update()
    {
        Faster();
        if (Speed > 5.0f && !GamePlay.instance.FeverOn)
        {
            Speed -= Time.deltaTime * 0.5f;
        }
        CheckTheLine();
        PlayTime -= Time.deltaTime;
        if (PlayTime < 0)
        {
            Debug.Log("Game Over");
            MeteoSpawner spawner = FindObjectOfType<MeteoSpawner>();
            spawner.StopMeteo();
        }
        if (BombPoint >= 100.0f) // ��ź ������ ä����, playtime �߰�
        {
            BombFull();
        }

        if (Combo!=0 && Combo%50==0 && !FeverOn) // �ǹ�Ÿ��(7������)
        {
            FeverTimeStart();
        }

    }
}
