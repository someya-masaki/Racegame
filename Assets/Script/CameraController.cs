using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //プレイヤーを変数に格納
    public GameObject Player;

    Vector3 PlayerPos;

    //回転させるスピード
    public float rotateSpeed = 3.0f;

    // Use this for initialization
    void Start()
    {
        //Playerの情報を取得
        Player = GameObject.Find("Player");
        PlayerPos = Player.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        //Playerの移動量分、自分（カメラ）も移動する
        transform.position += Player.transform.position - PlayerPos;

        //プレイヤー位置情報
        PlayerPos = Player.transform.position;

        //回転させる角度
        float angle = Input.GetAxis("ArrowKeyH") * rotateSpeed;

        //カメラを回転させる
        transform.RotateAround(PlayerPos, Vector3.up, angle);
    }
}
