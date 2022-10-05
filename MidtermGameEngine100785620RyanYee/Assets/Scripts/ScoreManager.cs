using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }



    public void ChangeScore(int CoinValue)
    {
        score += CoinValue;
        Debug.Log(score);
    }
}