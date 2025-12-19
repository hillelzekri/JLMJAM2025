using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleAnable : MonoBehaviour
{
    [SerializeField] GameObject[] candoles;


    public void AddCandle()
    {
        if (AllLighted())
        {
            return;
        }
        int i = 0;
        while (candoles[i].activeInHierarchy)
        {
            i++;
        }
        //candoles[i].SetActive(true);
        candoles[i].SetActive(true);

    }
    private bool AllLighted()
    {
        foreach (GameObject candle in candoles)
        {
            if (!candle.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }


 
}
