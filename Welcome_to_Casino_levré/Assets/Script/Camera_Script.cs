using System.Collections;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    public bool Iscinematic = false;


    // Update is called once per frame
    void Update()
    {
        
        if(!Iscinematic)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset + new Vector3(0, -8, 0), ref velocity, timeOffset);
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
}
