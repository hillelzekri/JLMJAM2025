using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHealth : MonoBehaviour
{
    
   public float maxhealth;
    public static float health;
    [SerializeField] float remainingTime = 10;
    [SerializeField] Light candleLight;
    [SerializeField] float maxintesenty = 1.5f;
    [SerializeField] float lifeTime = 10f;

    private float _timePassed;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 1;
        remainingTime = lifeTime;
        candleLight.intensity = maxintesenty;
        health = maxhealth;
    }
    private void Update()
    {

        healthReduse();
        candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICandle"))
        {
            health = candleLight.intensity;

        }
    }
    void healthReduse()
    {
      
       
        remainingTime -= Time.deltaTime;
        // remainingTime = 129 
        // remainingTime / 60 = 2;
        // remainingTime % 60 = 9;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        if (remainingTime == Time.deltaTime)
        {

          
            health -= 5;
          
        }
      
    }
    void UpdateTimerText()
    {

    


    }
  
}
