using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playermovement : MonoBehaviour
{
    public static playermovement Instance;


    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] float Speed = 1.0f;

    [SerializeField] Transform CameraTransform;
    [SerializeField] float timeBetweenSteps = 0.5f;
    Animator animator;
    Rigidbody rb;
    private float stepTimer = 0;




    void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();


    }
    private void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movez = Input.GetAxisRaw("Vertical");

        if (movex != 0 || movez != 0)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer < 0)
            {
                //soundManager.Instance.playsounds("footstep");
                stepTimer = timeBetweenSteps;
            }
        }
    }
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
