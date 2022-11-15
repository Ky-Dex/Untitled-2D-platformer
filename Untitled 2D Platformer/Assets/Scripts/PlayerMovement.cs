using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerBody;
    CapsuleCollider2D coll;
    Animator anim;
    SpriteRenderer sprite;
    float dirX;
    enum MovementState {idle, run, jump, fall }


    [SerializeField] LayerMask jumpableGround;
    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerBody.bodyType != RigidbodyType2D.Static)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            playerBody.velocity = new Vector2(dirX * speed, playerBody.velocity.y);
            UpdateAnimationState();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                Jump();
        }
    }

    void Jump()     //Player jump
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower);
    }

    void UpdateAnimationState()             //Sets animation states
    {
        MovementState state;

        if (dirX > 0f)
        {
            sprite.flipX = false;
            state = MovementState.run;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
            state = MovementState.run;
        }
        else
            state = MovementState.idle;

        if (playerBody.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (playerBody.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    bool isGrounded()       //checks if player is grounded
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
