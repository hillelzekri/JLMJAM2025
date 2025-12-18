

using UnityEngine;



public class OnSeenFollow : MonoBehaviour
{
    Animator animator;
    [SerializeField]  float speed = 5f;
   [SerializeField] Transform Player;
    public bool PlayerSeen = false;
    [SerializeField] float Radius = 1;
    [SerializeField] float DistanceFromPlayer = 2;
    bool isCumpted= false;
    [SerializeField] Light candleLight;
   [SerializeField] FireHealth fireHealth;

    private bool collected = false;


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
            if (Vector3.Distance(transform.position, Player.position) <= Radius)
            {
             
                candleLight.intensity = 1.5f;
                if (!collected)
                {
                    fireHealth.CandleCollcted(gameObject);
                    collected = true;
                }

            }
            if (Vector3.Distance(transform.position, Player.position) >= DistanceFromPlayer)
            {
                Vector3 direction = (Player.transform.position - transform.position);
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
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

