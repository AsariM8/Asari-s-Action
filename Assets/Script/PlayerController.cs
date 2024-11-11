using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpForce;
    public GroundChecker gc;
    private Rigidbody2D rb;
    private float x, y;
    private bool isGround;
    private bool onSpace;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGround = gc.IsGround();
        onSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (isGround && Input.GetKeyDown(KeyCode.Space)) onSpace = true;

    }

    void FixedUpdate()
    {

        if (isGround && onSpace)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        // 移動する向きとスピードを代入する
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        isGround = gc.IsGround();
        if (isGround == true) onSpace = false;
        Debug.Log(isGround);
        Debug.Log(onSpace);
    }
}
