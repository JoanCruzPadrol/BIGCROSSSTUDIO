using UnityEngine;

public class playerCharacterController : MonoBehaviour
{
    //   private string _name;
    //   private int _level;
    //   private int _life;

    //speed of Movement

    private Vector2 playerVelocity;
    public float playerSpeed = 2f;

    //to flip the sprite
    bool facingLeft = true;

    //for jumping
    bool playerGrounded;
    private float jumpHeight = 1.5f;
    private float playerWeight = -8.9f;

    //to represent Animator
    Animator anim;

    
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 650f;

    


    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = getComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); //movement through arrow keys

       
        rBody.velocity = new Vector2(move * playerSpeed,
            rBody.velocity.y);

        //establir la nostra velocitat.
        anim.SetFloat("Speed",
            Mathf.Abs(move));

        if (move < 0  && !facingLeft)
        {
            Flip();
        }
        else if (move > 0 && facingLeft)
        {
            Flip();
        }
    }

    
    void Update()
    {
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y + playerWeight * Time.deltaTime;
        

    }

    //flipping
    void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
