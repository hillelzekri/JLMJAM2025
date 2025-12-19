
using UnityEngine;



public class playermovement : MonoBehaviour
{
    public static playermovement Instance;


    [SerializeField] float rotationSpeed = 360f;
    [SerializeField] float Speed = 1.0f;

    [SerializeField] Transform CameraTransform;
    [SerializeField] float timeBetweenSteps = 0.5f;
    Animator animator;
    Rigidbody rb;
    private float stepTimer = 0;
    public float jumpForce = 5f;



    void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();


    }
    private void Update()
    {
        if (Input.anyKey)
        {
            UIManager.Instance.HideStartManu();
        }
        Move();
       
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        soundManager.Instance.playsounds("JumpingClip");
    }
    private void Move()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movez = Input.GetAxisRaw("Vertical");
       

        Vector3 movement = new Vector3(movex, 0, movez);


        movement = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * movement;
        movement.Normalize();
        transform.Translate(movement * Speed * Time.deltaTime, Space.World);


        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


        if (movex != 0 || movez != 0)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer < 0)
            {
                soundManager.Instance.playsounds("footstep");
                stepTimer = timeBetweenSteps;
            }
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
           
        }
    }
}
