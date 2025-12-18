

using UnityEngine;



public class OnSeenFollow : MonoBehaviour
{
    Animator animator;
    [SerializeField]  float speed = 5f;
   [SerializeField] Transform Player;
    public bool PlayerSeen = false;
    [SerializeField] float Radius = 1;
    bool isCumpted= false;
    [SerializeField] Light candleLight;



    void Start()
    {
    

        if (Player == null)
        {
            print("Player not found");
            return;   
        }
        PlayerSeen = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        ;
        if (Vector3.Distance(transform.position, Player.position) <= Radius)
        {
            PlayerSeen = true;
        }
        follow(); 
    }

   public void follow()
    {
        if (PlayerSeen && !isCumpted)
        {
            if (Vector3.Distance(transform.position, Player.position) >= Radius)
            {
                Vector3 direction = (Player.transform.position - transform.position);
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
                candleLight.intensity = 1.5f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = (other.transform.position - transform.position);
        print("Campfire detected, moving towards it");
        transform.position = Vector3.MoveTowards(transform.position, other.transform.position + direction, Time.deltaTime * speed);
        PlayerSeen = false;
        isCumpted = true;
        return;
    }
}

