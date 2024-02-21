using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    //Servent à appeler le système de respawn, le code du Player ainsi que son animator
    private Transform respawn;

    private Player_controler player;
    private Animator animator;

    private void Awake()
    {
        //Servent à définir les variables appelées 
        respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        //Prend l'animator du player
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_controler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si le Player rentre dans le collider de la death zone
        if (collision.CompareTag("Player"))
        {
            //Le Player se freeze 
            player.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            //Son animation de mort se joue
            animator.Play("player_mort");
            //Le Player ne peut plus être contrôlé 
            player.enabled = false;

            //Sert à lancer le code de replacement du Player
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);

        //Définit où renvoyer le joueur
        collision.transform.position = respawn.position;

        //Annonce le passage de l'animation de mort à celle de idle
        animator.Play("player_mort");

        //Force une attente de 1 frame
        yield return new WaitForSeconds(1f);

        //Réactive le contrôle du Player et freeze sa rotation (son axe Z)
        player.enabled = true;
        player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
