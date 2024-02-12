using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelRepository : MonoBehaviour
{
    #region Public Variables
    public int levelCount = 12;
    #endregion

    #region Private Variables
    #endregion

    #region const Variables
    private string REPOSITORY_NAME = "levelRepository";
    #endregion

    #region Public Methods
    public bool IsLocked(int i)
    {
        string[] s = RetriveLevelsFromRepoToArray();
        if (s[i]== "1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OpenLevel(int i)
    {
        string[] s = RetriveLevelsFromRepoToArray();
        s[i] = "1";
        string newS = ConvertToString(s);
        SaveRrpo(newS);
    }
    public void OpenNextLevel()
    {
        int index = 0;
        string[] s = RetriveLevelsFromRepoToArray();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == "0")
            {
                index = i;
                break;
            }
        }
        OpenLevel(index);
    }
    public bool[] RetriveAllLevels()
    {
        bool[] levelArray = new bool[levelCount];
        string[] levels = RetriveLevelsFromRepoToArray();
        for (int i = 0; i < levelCount; i++)
        {
            if (levels[i] == "1")
            {
                levelArray[i] = true;
            }
            else
            {
                levelArray[i] = false;
            }
        }
        return levelArray;
    }
    #endregion

    #region Private Methods
    private string[] RetriveLevelsFromRepoToArray()
    {
        string levels =PlayerPrefs.GetString(REPOSITORY_NAME);
        return levels.Split('-');
    }
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        if(PlayerPrefs.HasKey(REPOSITORY_NAME) == false)
        {
            string s = "1-0-0-0-0-0-0-0-0-0-0-0";
           
            SaveRrpo(s);
        }
    }
    private string ConvertToString(string[] s)
    {
        string newS = "";
        for (int i = 0;i < s.Length;i++)
        {
            newS += s[i]; //newS = newS + s[i];          
            if (i != s.Length - 1)
            {
                newS = newS + "-";
            }
        }
        return newS;
    }
    private void SaveRrpo(string s)
    {
        PlayerPrefs.SetString(REPOSITORY_NAME, s);
    }
    #endregion
}
