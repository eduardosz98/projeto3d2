using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public float dodgeSpeed = 5;
    public float rollSpeed = 5;
    public static float rollIncrease = 0.1f;
    public static int numeroVidas = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
        rb.AddForce(horizontalSpeed, 0, rollSpeed * rollIncrease);
    }
}
