using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();    
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Update() {
        if(Input.GetButtonDown("Jump") && !anim.GetBool("isJumping")) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        
        if(Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

        if(Input.GetButtonDown("Horizontal"))
        spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if(rigid.velocity.normalized.x == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

    }
    // Update is called once per frame
    void FixedUpdate()
    {  
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)
        rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < -maxSpeed)
        rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);

        if(rigid.velocity.y < 0) {

            Debug.DrawRay(rigid.position, Vector3.down, new Color(0,1,0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if(rayHit.collider != null) {
                Debug.Log(rayHit.collider.name);
                if(rayHit.distance < 0.5f) {
                    anim.SetBool("isJumping", false);
                }
            }

        }
        
    }
}
