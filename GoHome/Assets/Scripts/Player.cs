using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(this.transform.position.x>-1)
                this.transform.position -= new Vector3(1.0f, 0.0f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(this.transform.position.x<1)
            this.transform.position += new Vector3(1.0f, 0.0f, 0.0f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Move();   
    }
}
