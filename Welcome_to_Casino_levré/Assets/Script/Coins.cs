using UnityEngine;
using TMPro;
public class Coins : MonoBehaviour
{
    public static int Jeton = 0;
    public TextMeshProUGUI textCoins;
    private AudioSource ads;

    private void Start()
    {
        ads = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jeton"))
        {
            print("we have collected an item");
            Jeton++;
            textCoins.text = Jeton.ToString();
            ads.Play();
            Destroy(collision.gameObject);
        }


    }
}
