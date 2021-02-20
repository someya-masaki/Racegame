using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool Grounded;
    public float Jumppower;
    public Vector3 localGravity;
    public float moveSpeed = 10;
    public float blomSpeed = 1000;
    //回転させるスピード
    public float rotateSpeed = 3.0f;
    // 自分を映しているカメラ
    public GameObject camera;

    void Start()
    {
        //  rbにRigidbodyの値を代入する
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        FixedUpdate();
        if (Grounded == true)
        {
            // スペースキーが押されたら上に飛ぶ
            if (Input.GetKeyDown(KeyCode.Space))  
            {
                Grounded = false;
                rb.AddForce(Vector3.up * Jumppower);
            }
        }
    }

    private void FixedUpdate()
    {
        // Rigidbodyを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // 方向キーの入力
        float x = Input.GetAxis("Horizontal"); // 横軸
        float z = Input.GetAxis("Vertical");   // 縦軸

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        SetLocalGravity();

        if (x != 0 || z!= 0)
        {
            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;
            // 力を加える
            rigidbody.AddForce(moveForward * moveSpeed);
        }
    }

    private void SetLocalGravity()
    {
        rb.AddForce(localGravity, ForceMode.Acceleration);
    }

    // 衝突したときに呼ばれる処理
    void OnCollisionEnter(Collision collision)
    {
        // Poleと衝突したか
        if (collision.gameObject.CompareTag("Pole"))
        {
            // 衝突情報を取得
            ContactPoint contact = collision.contacts[0];

            // プレイヤーを吹き飛ばす処理
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(contact.normal * blomSpeed);
        }

        //  地面に触れた時の処理
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
