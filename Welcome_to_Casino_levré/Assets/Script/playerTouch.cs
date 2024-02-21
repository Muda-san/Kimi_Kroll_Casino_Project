using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTouch : MonoBehaviour
{

    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            transform.parent = collision.gameObject.transform;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "platform")
        {
            test = true;
            transform.parent = null; 
        }
    }
     
}
