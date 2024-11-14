using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpForce;
    public RayCastGroundCheck gc;
    private Rigidbody2D rb;
    private float x, y;
    public bool isGround, isFalling, isJumping;
    private bool preGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = gc.IsGround();
        preGround = isGround;
        isFalling = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (isGround && Input.GetKeyDown(KeyCode.Space)) isJumping = true;
    }

    void FixedUpdate()
    {

        if (isGround && isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
        }
        // 移動する向きとスピードを代入する
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        
        isGround = gc.IsGround();   // 接地判定
        if (!isGround && !isJumping) isFalling = true;  // 落下判定
        if (isGround && !preGround) // 着地判定
        {
            isJumping = false;
            isFalling = false;
        }
        preGround = isGround;
    }
}
