
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField] AudioClip maintrack;
    [SerializeField] AudioClip libary;
    [SerializeField] AudioClip CollectClip;
    [SerializeField] AudioClip StartingLevelClip;
    [SerializeField] AudioClip EndGameClip;
    [SerializeField] AudioClip cumpclip;
    [SerializeField] AudioClip Timer;
    AudioSource audioSource;
    public static soundManager Instance;
   [SerializeField] List<AudioClip> footsteps = new List<AudioClip>();


    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        audioSource.clip = maintrack;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void playsounds(string soundname)
    {

        switch (soundname)
        {
            case "collect":
                audioSource.PlayOneShot(CollectClip);
                break;
            case "endlevel":
                audioSource.PlayOneShot(EndGameClip);
                break;
            case "cumpclip":
                audioSource.PlayOneShot(cumpclip);
                break;
            case "timersound":
                audioSource.PlayOneShot(Timer);
                return;
            case "footstep":
                int randomIndex = Random.Range(0, footsteps.Count);
                audioSource.PlayOneShot(footsteps[randomIndex]);
                break;
            case "libary":
                audioSource.PlayOneShot(libary);
                return;

        }

    }
}