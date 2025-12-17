using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public static playermovement Instance;


    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] float Speed = 1.0f;

    [SerializeField] Transform CameraTransform;
    Animator animator;
    Rigidbody rb;




    void Start()

    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();


    }
    //private void Update()
    //{
    //    float movex = Input.GetAxisRaw("Horizontal");
    //    float movez = Input.GetAxisRaw("Vertical");


    //    Vector3 movement = new Vector3(movex, 0, movez);


    //    movement = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
    //    movement.Normalize();
    //    transform.Translate(movement * Speed * Time.deltaTime, Space.World);
    //}
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0, z);
        move = Quaternion.AngleAxis(CameraTransform.eulerAngles.y, Vector3.up) * move;
        move.Normalize();

        rb.MovePosition(rb.position + move * Speed * Time.fixedDeltaTime);
    }
}
