using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private Rigidbody2D RB;
    private Animator AM;
    public float JumpP = 700f;
    private bool isGrounded = false;
    private bool isdead = false;
    private int jumpcount = 0;
    public AudioClip twoj;
    public AudioClip death;
    private AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AM = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isdead)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0) && jumpcount < 2)
        {
            jumpcount++;

            if (jumpcount == 2)
            {
                AM.SetTrigger("Double");
                AS.PlayOneShot(twoj);
            }


            RB.velocity = Vector2.zero;
            RB.AddForce(new Vector2(0, JumpP));
            AS.Play();
            
        }

    
        else if(Input.GetMouseButtonUp(0) && RB.velocity.y > 0)
        {
            RB.velocity = RB.velocity * 0.35f;
        }

        else if(RB.velocity.y <= 0)
        {
            RB.velocity = RB.velocity * 1.01f;
        }

        AM.SetBool("Grounded", isGrounded);
    }
    private void Die()
    {
        AM.SetTrigger("Die");
        AS.PlayOneShot(death);
        RB.velocity = Vector2.zero;
        isdead = true;

        GameManager.instance.OnPlayerDead();
        GameManager.instance.offsound();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dead" && !isdead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpcount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
