using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;



    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset + new Vector3(0,-8,0), ref velocity, timeOffset);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset + new Vector3(0, 5, 0), ref velocity, timeOffset);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }

    }
}
