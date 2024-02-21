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
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position -= Vector3.up * 50 * Time.deltaTime;
        }

    }
}
