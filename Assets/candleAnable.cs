
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
        candoles[i].SetActive(true);
        if (i == candoles.Length - 1)
        {
            UIManager.Instance.ShowEndMenu();
            //end the game
            return;
        }
        print(AllLighted());
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
