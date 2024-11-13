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
    private bool JumpStarted = false;
    private int cooldown = 10;

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
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            // JumpStarted = true;
            cooldown = 10;
        }

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

        // ジャンプした場合，接地判定を1サイクル待機
        // if (!JumpStarted) isGround = gc.IsGround();
        // else JumpStarted = false;
        // if (cooldown > 0) cooldown--;
        // else isGround = gc.IsGround();
        if (!isGround && !isJumping) isFalling = true;
        isGround = gc.IsGround();

        // 着地判定
        if (isGround && !preGround)
        {
            isJumping = false;
            isFalling = false;
        }
        preGround = isGround;

        Debug.Log("isGround: " + isGround);
        Debug.Log("isJumping: " + isJumping);
    }
}
