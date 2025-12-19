
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class FireHealth : MonoBehaviour
{
    
   
   

    [SerializeField] float remainingTime;
    [SerializeField] Light candleLight;
    [SerializeField] float maxintesenty = 1.5f;
    [SerializeField] float lifeTime = 30f;
    [SerializeField] float multiplier = 1.1f;
    public static int candleCollectedAmunt = 0;
    public static List<GameObject> candles = new List<GameObject>();
    [SerializeField] candleAnable CandleAnable;
    [SerializeField] ParticleSystem fireParticles;
    [SerializeField] GameObject directionalLight;
    private float _fireEmission;
    [SerializeField] Transform lustCheckPoint;
    public static int ArielCounter = 0;


    public static bool PlayerDied = false;


    //ignition variables
    [SerializeField] float ignitionTime = 3f;
    private playermovement movementScript;

    //Starting Text
    [SerializeField] TextMeshProUGUI ignitionText;

    private float _timePassed;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerDied)
        {
            if (ignitionText != null)
                ignitionText.gameObject.SetActive(false);
            //testing Ignition at start.
            movementScript = GetComponent<playermovement>();
            if (movementScript != null)
                movementScript.enabled = false;

            // Stop fire if it plays on Awake
            if (fireParticles != null)
                fireParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // Start ignition sequence
            StartCoroutine(IgniteAndStartGame());
        }
        else
        {
            if (movementScript != null)
                movementScript.enabled = true;
        }
            //------------------------------------------------------------------------


        remainingTime = lifeTime;
        candleLight.intensity = maxintesenty;
        _fireEmission = fireParticles.emission.rateOverTime.constant;
        

        //directionalLight.SetActive(false);


    }
    private void Update()
    {

        healthReduse();
        candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;
        fireParticles.emissionRate = (remainingTime / lifeTime) * _fireEmission;
     
        if(remainingTime < 0)
        {
            RestartGame();
        }
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
            print("candles.Count is " + candles.Count);
            //remainingTime = lifeTime;
            //candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;

            if (candles != null && candles.Count > 0)
            {
                foreach (GameObject candle in candles)
                {
                    CandleAnable.AddCandle();
                    candle.SetActive(false);
                    print("ArielCounterIs: " + ArielCounter);
                    lifeTime = lifeTime * multiplier;
                    remainingTime = lifeTime;
                    candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;
                    candleLight.intensity = (remainingTime / lifeTime) * maxintesenty;
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
    public void RestartGame()
    {
        PlayerDied = true;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }
    IEnumerator IgniteAndStartGame()
    {
        //Setup for fade out, cause chatGPT told me
        ignitionText.color = new Color(
            ignitionText.color.r,
            ignitionText.color.g,
            ignitionText.color.b,
            1f
        );
        ignitionText.gameObject.SetActive(true);


        //Activate text
        if (ignitionText != null)
            ignitionText.gameObject.SetActive(true);

        // Activate fire particle effect
        if (fireParticles != null)
            fireParticles.Play();

        // Wait for ignition duration
        yield return new WaitForSeconds(ignitionTime);
        
        //Fade out message
        if (ignitionText != null)
            StartCoroutine(FadeOutText(ignitionText, 1f));

        // Enable player movement
        if (movementScript != null)
            movementScript.enabled = true;

        Debug.Log("Player candle is ignited! Game started!");
    }
    IEnumerator FadeOutText(TextMeshProUGUI text, float duration)
    {
        Color startColor = text.color;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / duration);
            text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        text.gameObject.SetActive(false);
    }
}
