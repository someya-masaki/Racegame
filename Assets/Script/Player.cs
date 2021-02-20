using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 自分を映しているカメラ
    public GameObject camera;
    // 移動速度
    public float move_speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 入力方向（左、右）
        int inputvec = 0;
        if (Input.GetKey(KeyCode.A))
        {
            inputvec = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputvec = 1;
        }

        // 移動速度
        float speed = inputvec * move_speed;
        if (speed != 0)
        {
            // ここで移動する方向を決定
            Vector3 move = camera.transform.right * speed;
            // ここで繁栄
            transform.position += move;
        }
    }
}
