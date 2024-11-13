using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerController pcs;
    private float zoomedOutSize = 7f;  // ズームアウト時のサイズ
    private float defaultSize = 5f;    // 通常時のサイズ
    public float zoomSpeed = 2f;      // ズーム速度

    private Camera cameraComponent;
    private float targetSize;
    private bool isZooming = false;

    void Start()
    {
        pcs = player.GetComponent<PlayerController>();
        zoomedOutSize = pcs.jumpForce * 2;
        zoomSpeed = zoomedOutSize / 4;
        // 自身にアタッチされたCameraコンポーネントを取得
        cameraComponent = GetComponent<Camera>();

        // カメラが存在しない場合のエラーチェック
        if (cameraComponent == null)
        {
            Debug.LogError("このスクリプトはCameraオブジェクトにアタッチする必要があります。");
        }

        // 初期ターゲットサイズを設定
        targetSize = defaultSize;
    }

    void Update()
    {
        Debug.Log("targetSize" + targetSize);
        // プレイヤーの垂直速度をチェック
        float yVelocity = player.GetComponent<Rigidbody2D>().velocity.y;

        // 上昇中（ジャンプ）
        if (yVelocity > 0.1f)
        {
            if (targetSize != zoomedOutSize)
            {
                targetSize = zoomedOutSize;
                isZooming = true;
            }
        }
        // 下降中（ジャンプ後の落下）
        else if (yVelocity < -0.1f)
        {
            if (targetSize != defaultSize)
            {
                targetSize = defaultSize;
                isZooming = true;
            }
        }
        // 着地時
        else if (yVelocity == 0 && !pcs.isJumping)
        {
            if (targetSize != defaultSize)
            {
                targetSize = defaultSize;
                isZooming = true;
            }
        }

        // ズームイン・ズームアウトを補間
        if (isZooming && pcs.isJumping)
        {
            cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);

            // 目標サイズに十分近づいたら停止
            if (Mathf.Abs(cameraComponent.orthographicSize - targetSize) < 0.01f)
            {
                cameraComponent.orthographicSize = targetSize;
                isZooming = false;
            }
        }
    }
}
