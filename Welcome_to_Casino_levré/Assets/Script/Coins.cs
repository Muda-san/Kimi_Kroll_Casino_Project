using UnityEngine;
using TMPro;
using System.Collections;

public class Coins : MonoBehaviour
{
    public static int Jeton = 0;
    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jeton"))
        {
            print("we have collected an item");
            Jeton++;
            textCoins.text = Jeton.ToString();
            StartCoroutine(son(collision));
        }


    }
    public IEnumerator son(Collider2D collision)
    {
        AudioSource Audios = collision.gameObject.GetComponent<AudioSource>();
        Audios.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(collision.gameObject);
    }
}
