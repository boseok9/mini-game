using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCatch : MonoBehaviour
{

    private float Speed => GamePlay.instance.Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GamePlay.instance.BecomeStar();
            GamePlay.instance.Score += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0.0f, -1.0f, 0.0f) * Speed * Time.deltaTime;
        if (this.transform.position.y <= -3) { 
            Destroy(gameObject);
        }
    }
}
