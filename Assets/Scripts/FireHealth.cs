using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHealth : MonoBehaviour
{
    
   public float maxhealth;
    public static float health;

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
    public static int ArielCounter = 0;



    private float _timePassed;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 1;
        remainingTime = lifeTime;
        candleLight.intensity = maxintesenty;
        _fireEmission = fireParticles.emission.rateOverTime.constant;
        health = maxhealth;

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
        if (remainingTime == Time.deltaTime)
        {
            health -= 5; 
        }
   
    }
    public void  CandleCollcted(GameObject candle)
    {
        candleCollectedAmunt++;
        print("Candle Collected"+ candleCollectedAmunt);
        candles.Add(candle);


    } 
}
