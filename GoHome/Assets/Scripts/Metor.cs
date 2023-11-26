using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Image;

    // Start is called before the first frame update

    private float Speed => GamePlay.instance.Speed;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Destroy(gameObject);
            Destroy(GamePlay.instance.LiveMetor[0][0]);
            Destroy(GamePlay.instance.LiveMetor[0][1]);
            GamePlay.instance.LiveMetor.RemoveAt(0);

            GamePlay.instance.BombPoint = 0.0f;
            GamePlay.instance.Combo = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0.0f, -1.0f, 0.0f) * Speed * Time.deltaTime;
        /* if (this.transform.position.y <= -3) { 
            Destroy(gameObject);
            GamePlay.instance.LiveMetor.RemoveAt(0);
            GamePlay.instance.BombPoint += 1.0f;
            GamePlay.instance.Combo += 1.0f;
        } */
        Debug.Log($"Speed : {Speed}, BombPoint : {GamePlay.instance.BombPoint} , Combo : {GamePlay.instance.Combo}");
    }
}
