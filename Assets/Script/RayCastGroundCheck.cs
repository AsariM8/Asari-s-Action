using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGroundCheck : MonoBehaviour
{
    // プレイヤーの接地判定のための変数
    public Transform groundCheck; // プレイヤーの足元に配置するTransform
    public float checkRadius = 0.2f; // Rayの長さ
    public LayerMask groundLayer; // 地面のレイヤー

    private bool isGrounded;

    void Update()
    {
        // groundCheck位置から下向きにRayを発射し、地面に当たるかを確認
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, checkRadius, groundLayer);

        // デバッグ用: シーンビューでRayを確認するため
        Debug.DrawRay(groundCheck.position, Vector2.down * checkRadius, isGrounded ? Color.green : Color.red);
    }

    public bool IsGround()
    {
        return isGrounded;
    }
}