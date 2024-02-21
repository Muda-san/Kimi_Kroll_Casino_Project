using System.Collections;
using UnityEngine;

public class gardsxript : MonoBehaviour
{
    public Sprite cogné;
    public Sprite pascogné;
    public SpriteRenderer sp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("AttackHitBox"))
        {
            StartCoroutine(cognage());

        }
    }

    public IEnumerator cognage()
    {
        //BRUIT DE BOOM
        sp.sprite = cogné;

        yield return new WaitForSeconds(.5f);

        sp.sprite = pascogné;


    }
}
