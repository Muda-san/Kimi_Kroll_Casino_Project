using UnityEngine;
using System.Collections;

public class Player_controler: MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Transform groundCheck;

    public BoxCollider2D Playercollider;

    public float maxSpeed;
    public float jumpSpeed;

    
    private bool isAttacking = false;
    private bool ismoving = false;
    public bool invulnerable = false;

    bool isGrounded;

    [SerializeField]
    GameObject attackHitBox;
    public GameObject GameOverMenu;

    public int health;

    public static Player_controler instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Player_controler dans la scène");
            return;
        }

        instance = this;
    }

        // Start is called before the first frame update
        void Start()
        {

            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            attackHitBox.SetActive(false);

        }
        //==========================================================
        //Update is called once per frame
        //==========================================================
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && !isAttacking)
            {
                isAttacking = true;
                animator.Play("player_attack");

                StartCoroutine(DoAttack());
            }

            if (health <= 0)
            {
                Playerdeath();
            }


        }
        

        IEnumerator DoAttack()
        {
            attackHitBox.SetActive(true);
            yield return new WaitForSeconds(.5f);
            attackHitBox.SetActive(false);
            isAttacking = false;

        }

        //==========================================================
        // Update is called once per frame
        //==========================================================
        void FixedUpdate()
        {
            if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Plateforme")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
                ismoving = true;
                if (isGrounded && !isAttacking)
                animator.Play("player_walk");
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
                ismoving = true;
                if (isGrounded && !isAttacking)
                animator.Play("player_walk");
                transform.localScale = new Vector3(-1, 1, 1);

            }
            else if(health > 0 && ismoving == false && !invulnerable)
            {
                if (!isAttacking && isGrounded)
                {
                    animator.Play("player_idle");
                }

                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            else
            {
                ismoving = false;
            }
            
            if (Input.GetKey("space") && isGrounded)
            {
                ismoving = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                animator.Play("player_jump");
            }
        }

    public void AttackStop()
    {
        attackHitBox.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if(!invulnerable)
        {
            health -= damage;
            invulnerable = true;
            StartCoroutine(invulnerableWait());
        }
    }
    private IEnumerator invulnerableWait()
    {
        animator.Play("player_degat");
        yield return new WaitForSeconds(1f); //invulnerable time
        invulnerable = false; 
    }

    public void Playerdeath()
    {
        animator.Play("player_mort");
        Playercollider.enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        maxSpeed = 0;
        jumpSpeed = 0;

        GameOverMenu.SetActive(true);

    }
    public void PlayerStop()
    {
        Playercollider.enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        maxSpeed = 0;
        jumpSpeed = 0;

    }


}
