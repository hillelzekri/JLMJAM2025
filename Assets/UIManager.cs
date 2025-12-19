using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] GameObject StartMenu;
    [SerializeField] CanvasGroup StartMenufade;
    [SerializeField] CanvasGroup EndMenu;
    [SerializeField] CanvasGroup RespawnPanel;
    [SerializeField] CanvasGroup PauseMenu;
    [SerializeField] private float fadeSpeed = 1f;

    private void Start()
    {
        if (Instance == null)
        Instance = this;
    }
   public void ShowStartManu()
    {

      
        
    }
    public void ShowRespawnPanel()
    {

        StartCoroutine(FadeinRespawnPanel());
    }
    public void HideRespawnPanel()
    {
        StartCoroutine(FadeOutRespawnPanel());
    }

    public void HideStartManu()
    {
        StartCoroutine(FadeOutStartMenu());
    }

    private IEnumerator FadeinRespawnPanel()
    {
        while (RespawnPanel.alpha < 1f)
        {
            RespawnPanel.alpha += fadeSpeed * Time.deltaTime;
            yield return null;
        }

        RespawnPanel.alpha = 1f;
        
    }
    private IEnumerator FadeOutRespawnPanel()
    {
        while (RespawnPanel.alpha > 0f)
        {
            RespawnPanel.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        RespawnPanel.alpha = 0f;
    }
    private IEnumerator FadeOutStartMenu()
    {
        while (StartMenufade.alpha > 0f)
        {
            StartMenufade.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        StartMenufade.alpha = 0f;
    }
    public void ShowEndMenu()
    {
        StartCoroutine(FadeinEndMenuu());
    }
    private IEnumerator FadeinEndMenuu()
    {
        while (EndMenu.alpha < 1f)
        {
            EndMenu.alpha += fadeSpeed * Time.deltaTime;
            yield return null;
        }

        EndMenu.alpha = 1f;
    }
}
