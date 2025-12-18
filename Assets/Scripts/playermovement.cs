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




    void Start()

    {

        animator = GetComponent<Animator>();


    }
    private void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movez = Input.GetAxisRaw("Vertical");


        Vector3 movement = new Vector3(movex, 0, movez);


        movement = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
        movement.Normalize();
        transform.Translate(movement * Speed * Time.deltaTime, Space.World);
    }
}
