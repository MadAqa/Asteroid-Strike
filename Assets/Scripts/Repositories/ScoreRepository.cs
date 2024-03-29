using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRepository : MonoBehaviour
{
    #region Public Variables
    
    #endregion
    //-------------------------------
    #region Private Variables

    #endregion
    //-------------------------------
    #region Const Variables
    private const string lastScoreRepository = "lastScoreRepository";
    private const string highScoreRepository = "highScoreRepository";
    #endregion
    
    //-------------------------------
    #region Public Methods
    public void Push(int s)
    {
        Save(lastScoreRepository, s);
        int h = GetHighScore();
        if (s > h)
        {
            Save(highScoreRepository, s);
        }
    }
    public int GetLastScore()
    {
        return Retrive(lastScoreRepository);
    }
    public int GetHighScore() { 
        return Retrive(highScoreRepository);
    }
    #endregion
    //-------------------------------
    #region Private Methods
    private int Retrive(string key)// s means score
    {
       // PlayerPrefs.GetInt(key);
        return PlayerPrefs.GetInt(key);

    }
    private void Save(string key,int val)
    {
        PlayerPrefs.SetInt(key, val);
    }
    #endregion
}
