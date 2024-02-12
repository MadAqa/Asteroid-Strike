using UnityEngine;
using System.Collections;

public class CoinRepository : MonoBehaviour
{
    #region Public Variables
    public string RepositoryName { get {  return repositoryName; } }
    #endregion
    //--------------------------

    #region Private Variables
    private int coins;
    #endregion
    //--------------------------

    #region Const Variables
    private const string repositoryName = "coinRepository";
    #endregion
    //--------------------------

    #region Public Methods

    public int Get()
    {
        return coins;
        
    }
    public bool Pop(int count)
    {
        if (Has(count))
        {
            coins = coins - count;
            SaveRepo();
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Push(int count)
    {
        if(count > 0) 
        {
        coins = coins + count;
        SaveRepo(); 
        }
    }
    public void Save ()
    {
        SaveRepo(); 
    }
    #endregion
    //--------------------------

    #region Private Methods

    private bool Has(int count)
    {
        if (coins >= count) {
            
            return true;
        }
        
        return false;

    }
    private void Start()
    {
        if(PlayerPrefs.HasKey(repositoryName))
        {
            coins = Retrive();
        }
        else
        {
            coins = 0;
        }
      
      // coins = 2000;
      // SaveRepo();
    }
    private void SaveRepo()
    {
        PlayerPrefs.SetInt(repositoryName, coins);
        
    }
    private int Retrive()
    {
        
        return PlayerPrefs.GetInt(repositoryName);
    }

    #endregion

}
