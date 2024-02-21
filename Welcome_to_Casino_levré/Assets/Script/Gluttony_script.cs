using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gluttony_script : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb;
    Animator animator;

    public int health;
    public int degatdumonstre;

    public bool ismoving;
    public bool isattacking;
    public bool isDying = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float disToPlayer = Vector2.Distance(transform.position, player.position);

        if (disToPlayer < agroRange && health > 0)
        {
            //code to chase player
            ismoving = true;
        }
        if (ismoving == true && isattacking == false)
        {
            ChasePlayer();
        }

        else if (ismoving == false && isattacking == false)
        {
            //stop chasing player
            StopChasingPlayer();

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackHitBox")
        {
            Player_controler.instance.AttackStop();
            StartCoroutine(degat());

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_controler.instance.TakeDamage(degatdumonstre);
            animator.Play("Gluttony_degat");
        }
    }

    public IEnumerator death()
    {
        ismoving = false;
        isattacking = true;
        animator.Play("Gluttony_mort");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public IEnumerator degat()
    {
        rb.velocity = new Vector2(0, 0);
        ismoving = false;
        isattacking = true;
        animator.Play("Gluttony_degat");
        health -= 1;
        yield return new WaitForSeconds(0.5f);
        isattacking = false;

        //Si la vie est inférieur ou égale à 0

        if (health <= 0 && !isDying)
        {
            isDying = true;
            StartCoroutine(death());
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to left side of the player, so move right 
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

            animator.Play("Gluttony_walk");


        }
        else if (transform.position.x > player.position.x)
        {
            //enemy is to right side of the player, so move left
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);

            animator.Play("Gluttony_walk");

        }
    }

    void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        animator.Play("Gluttony_idle");
    }

    public void StopAttack()
    {
        animator.SetBool("Gluttony_attack", false);
    }

}
