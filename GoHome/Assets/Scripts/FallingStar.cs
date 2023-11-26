using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStar : MonoBehaviour
{
    private float Speed => GamePlay.instance.Speed;

    // Start is called before the first frame update



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GamePlay.instance.Score += 10;
        }
    }

    private void PlusScore()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0.0f, -1.0f, 0.0f) * Speed * Time.deltaTime;
        /*if (this.transform.position.y <= -3) { 
            Destroy(gameObject);
        }  */

        Debug.Log($"Speed : {Speed}, BombPoint : {GamePlay.instance.BombPoint} , Combo : {GamePlay.instance.Combo}");
    }
}
