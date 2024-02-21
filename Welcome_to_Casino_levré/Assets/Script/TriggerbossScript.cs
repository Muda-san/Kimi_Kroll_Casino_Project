using UnityEngine;

public class TriggerbossScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BarreVie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Boss.SetActive(true);
            BarreVie.SetActive(true);
            Destroy(gameObject);
        }
    }
}
