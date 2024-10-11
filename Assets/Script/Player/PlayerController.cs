using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb; //
    private Collider2D coll; //
    private Animator anim;

    #region Private Variables
    [SerializeField] private float speed = 8f;//
    [SerializeField] private float jumpForce = 10f;//
    [SerializeField] private LayerMask ground;//
    [SerializeField] private bool isJumping= false;//
    #endregion

    #region FiniteStateMachine
    private enum State {idle,running,jumping,falling,hurt}//
    private State state = State.idle;//
    #endregion


    void Awake()//
    {//
        rb = GetComponent<Rigidbody2D>();//
        coll = GetComponent<Collider2D>();//
        anim = GetComponent<Animator>();
    }//

    void Update()//
    {//
        if (Time.deltaTime != 0)//
        {//
            if (state != State.hurt)//
            {//
                Movement();//
            }//
            AnimationState();
            anim.SetInteger("state",(int)state);
        }//
    }//

    private void Movement()//
    {//
        float hDirection = Input.GetAxisRaw("Horizontal");//
        if (hDirection < 0)//
        {//
            rb.velocity = new Vector2(-speed, rb.velocity.y);//
            transform.localScale = new Vector2(-1,1);//
        }
        else if (hDirection>0)//
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);//
            transform.localScale = new Vector2(1,1);//
        }//
        else if (Input.GetButtonUp("Horizontal") && isJumping == false )//
        {//
            rb.velocity = new Vector2(0,rb.velocity.y);//
        }//

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))///
        {//
            Jump();//
        }//
    }//

    private void Jump()//
    {//
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);//
        state = State.jumping;
        isJumping=true;//
    }

    private void AnimationState()//
    {
        if ( state == State.jumping )//
        {
            if (rb.velocity.y < .3f)
            {
                state=State.falling;
            }
        }
        else if (state==State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
                isJumping=false;
            }
        }
        else if (state==State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x)<.1f)
            {
                state=State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x)>2f)
        {
            state=State.running;
        }
        else
        {
            state=State.idle;
        }
    }
}
