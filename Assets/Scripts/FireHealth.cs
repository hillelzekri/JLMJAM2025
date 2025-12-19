
using System.Collections.Generic;
using UnityEngine;

public class FireHealth : MonoBehaviour
{
    
   
   

    [SerializeField] float remainingTime;
    [SerializeField] Light candleLight;
    [SerializeField] float maxintesenty = 1.5f;
    [SerializeField] float lifeTime = 10f;
    public static int candleCollectedAmunt = 0;
    public static List<GameObject> candles = new List<GameObject>();
    [SerializeField] candleAnable CandleAnable;
    [SerializeField] ParticleSystem fireParticles;
    [SerializeField] GameObject directionalLight;
    private float _fireEmission;
    [SerializeField] Transform lustCheckPoint;
    public static int ArielCounter = 0;



    private float _timePassed;
    // Start is called before the first frame update
    void Start()
    {
        
        remainingTime = lifeTime;
        candleLight.intensity = maxintesenty;
        _fireEmission = fireParticles.emission.rateOverTime.constant;
        

        directionalLight.SetActive(false);


    }
    private void Update()
    {

        healthReduse();
        candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;
        fireParticles.emissionRate = (remainingTime / lifeTime) * _fireEmission;
     
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICandle"))
        {
            remainingTime = lifeTime;
            candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;
           
        }
        if (other.gameObject.CompareTag("Campfire"))
        {
            remainingTime = lifeTime;
            candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;

            if (candles != null && candles.Count > 0)
            {
                foreach (GameObject candle in candles)
                {
                    CandleAnable.AddCandle();
                    candle.SetActive(false);
                    maxhealth += 0.5f;
                    health = maxhealth;
                    print("ArielCounterIs: " + ArielCounter);
                }
                //print("bbbbbbbbbbbbbbbbbbbb");

                candles.Clear();
            }
        }
    }

    void healthReduse()
    {
       
        remainingTime -= Time.deltaTime;
     
        if (remainingTime <= 0 )
            {
            UIManager.Instance.ShowRespawnPanel();
            Invoke(nameof(Respawnplayer),2f);
        }
        
   
    }
    void Respawnplayer()
    {
       transform.position = lustCheckPoint.position;
        remainingTime = lifeTime;
        candleLight.intensity = maxintesenty;
        UIManager.Instance.HideRespawnPanel();

    }
    public void  CandleCollcted(GameObject candle)
    {
        candleCollectedAmunt++;
        print("Candle Collected"+ candleCollectedAmunt);
        candles.Add(candle);


    } 
}
