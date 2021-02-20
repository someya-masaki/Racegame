using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -50 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * Time.deltaTime * -1;
        }
    }
}
