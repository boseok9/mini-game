using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Meteo;
    [SerializeField] private GameObject StarCatch;

    // Start is called before the first frame update
    void Start()
    {
        StartMeteo();
    }

    private void StartMeteo()
    {
        StartCoroutine("CreativeMeteo");
    }

    public void StopMeteo()
    {
        StopCoroutine("CreativeMeteo");
    }

    IEnumerator CreativeMeteo()
    {
        Vector3[] Array = new Vector3[] { new Vector3(-1.0f, 6.0f, 0.0f), new Vector3(0.0f, 6.0f, 0.0f), new Vector3(1.0f, 6.0f, 0.0f) }; 
        while (true)
        {
            int idx1 = Random.Range(0, 3);
            int idx2 = (idx1 + Random.Range(1,3)) % 3;
            GameObject[] Metors = new GameObject[2];
            Metors[0] = Instantiate(Meteo, Array[idx1], Quaternion.identity);
            Metors[1] = Instantiate(Meteo, Array[idx2], Quaternion.identity);

            if (CreateStarCatch())
            {
                Vector3 StarPos = new Vector3 (-(Array[idx1].x + Array[idx2].x), 6.0f, 0.0f);
                GameObject obj = Instantiate(StarCatch, StarPos, Quaternion.identity);
            }
            
            GamePlay.instance.LiveMetor.Add(Metors);

            yield return new WaitForSeconds(3.5f/GamePlay.instance.Speed);
        }
    }

    private bool CreateStarCatch()
    {
        int x = Random.Range(0, 100);
        if (x >= 20) return true;
        else return false;
    }

}
