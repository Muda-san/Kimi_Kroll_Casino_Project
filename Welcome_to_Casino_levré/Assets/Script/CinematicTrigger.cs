using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour
{

    public Camera Maincamera;
    public Vector3 EndPosition;
    public float duration;

    public GameObject GroupeBandeNoirs;

    private bool CinematicON = false;

    private Camera_Script cmS;
    private Collider2D coll2D;


    private void Start()
    {
        coll2D = GetComponent<Collider2D>();
        cmS = Maincamera.GetComponent<Camera_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_controler.instance.PlayerStop();
        coll2D.enabled = false;

        cmS.Iscinematic = true; //Player cannot control camera
        CinematicON = true;

        GroupeBandeNoirs.SetActive(true);

        StartCoroutine(CameraToDestination());

    }


    private IEnumerator CameraToDestination()
    {
        float startTime = Time.time;
        Vector3 startPosition = Maincamera.transform.position;

        while (CinematicON)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            Maincamera.transform.position = Vector3.Lerp(startPosition, EndPosition, t);

            if (t >= 1f)
            {
                yield return new WaitForSeconds(3f); 
                CinematicON = false;
                GroupeBandeNoirs.SetActive(false);
            }

            yield return null;
        }

        cmS.Iscinematic = false;
        Player_controler.instance.PlayerStart();
    }
}
