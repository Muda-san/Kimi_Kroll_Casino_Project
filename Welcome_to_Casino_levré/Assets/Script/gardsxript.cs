using System.Collections;
using UnityEngine;

public class gardsxript : MonoBehaviour
{
    public Sprite cogn�;
    public Sprite pascogn�;
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
        sp.sprite = cogn�;

        yield return new WaitForSeconds(.5f);

        sp.sprite = pascogn�;


    }
}
