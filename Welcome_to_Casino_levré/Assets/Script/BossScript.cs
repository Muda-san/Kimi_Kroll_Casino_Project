using System.Collections;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int health = 15;
    public int damage = 2;

    public Transform groundCheck;
    public Transform BossShadow;
    public Transform player;

    private Animator animator;

    Rigidbody2D rb;
    SpriteRenderer spriterdr;
    private CapsuleCollider2D capp2D;

    public static bool bossIsspawn = false;
    public static bool bossDeafeated = false;
    public bool isOnGround;
    public bool isAttacking;
    public bool isDying;

    public static BossScript instance;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriterdr = GetComponent<SpriteRenderer>();
        capp2D = GetComponent<CapsuleCollider2D>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de BossScript dans la scène");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Plateforme"))&& !isDying)
        {
            isOnGround = true;
        }



        if (isOnGround && !isAttacking)
        {
            Attack();
        }

        if(health <= 0)
        {
            isDying = true;
            isOnGround = false;
            capp2D.enabled = false;
            rb.isKinematic = true;
            StartCoroutine(MortMechant());
           
        }
    }

    public IEnumerator MortMechant()
    {

        animator.Play("Greed_mort");

        yield return new WaitForSeconds(2f);
        bossDeafeated = true;
        Destroy(gameObject);
    }

    public void Attack()
    {
        
        StartCoroutine(AttackingPatern());
    }

    public IEnumerator AttackingPatern()
    {
        //Charge son attack
        animator.Play("Greed_ChargeSaut");
        yield return new WaitForSeconds(2f);
        animator.Play("Greed_saut");
        //Jump
        transform.position = new Vector3(BossShadow.transform.position.x, BossShadow.transform.position.y + 6, BossShadow.transform.position.z);
        rb.gravityScale = 0;
        isAttacking = true;
        animator.Play("Greed_PendantSaut");
        int timeinaire = 50;


        for (int i = 0; i < timeinaire; i++)
        {
            //SON GRAS VOLE
            BossShadow.transform.position = new Vector3(player.position.x, BossShadow.transform.position.y, BossShadow.transform.position.z);
        }

        yield return new WaitForSeconds(2.5f);

        //LA il retombe
        rb.gravityScale = 1;
        transform.position = new Vector3(BossShadow.transform.position.x, BossShadow.transform.position.y, BossShadow.transform.position.z);

        //CHANGER SPRITE EN MODE GMAL AU CUL
        animator.Play("Greed_atterissage");
        yield return new WaitForSeconds(5f);
        isAttacking = false;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("AttackHitBox"))
        {
            //Animation de se prendre un degat ça fait mal
            health -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_controler.instance.TakeDamage(damage);
        }
    }
}
