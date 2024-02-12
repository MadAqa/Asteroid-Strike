using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipEnums
{
    Green1, Green2, Green3, Red1, Red2, Red3, Blue1, Blue2, Blue3
}
public enum BulletType
{
    Laser, Rocket, Bomb
}

[System.Serializable]
public struct ShipStruct
{
    public ShipEnums key; //types of ship
    public GameObject ship; //ship prefab
    [Range(1,10)]
    public int speed; // ship speed
    [Range (1,10)]
    public int health; // health of ship
    [Range(1,3)]
    public int guns; // count of guns
    [Range(1,3)]
    public int bulletPower; //power of bullets
    public string model; // the name of ship
    public BulletType bulletType; // type of bullet
    public int price; // price of ship
    public bool isLocked; // age "true" bashe safine kharidary nashode
    [Range(0.0f,1f)]
    public float fireRate; //rate of fire
    public Sprite sprite;// sprite of space ship
}
public class ShipRepository : MonoBehaviour
{
    #region Public Variables
    public ShipStruct[] ships;
    public int shipsCount { get { return ships.Length; } }
    #endregion
    //-----------------------------------
    #region Private Variables

    #endregion
    //-----------------------------------
    #region Const Variables
    private const string currentShipRepo = "currentShiprepo";
    private const string shipsRepos = "shipsRepo";
    #endregion
    //-----------------------------------
    #region Public Methods
    public ShipStruct GetCurrentShip()
    {
        int index = PlayerPrefs.GetInt(currentShipRepo);
        /* if (ships[index].price == 0)
         {
             ships[index].isLocked = false;
         }
         else
         {
             ships[index].isLocked = true;
         }
         return ships[index]; */
        ships[index].isLocked = IsShipActive(index);
        return ships[index];
    }
    public ShipStruct GetShipByIndex(int i)
    {
        ships[i].isLocked = !IsShipActive(i);
        return ships[i];
    }
    public void SetCurrentShip(int i)
    {
        PlayerPrefs.SetInt(currentShipRepo, i);
    }
    public void ActiveNewShip(int i)
    {
        string s = RetriveShips();
        s = s + i.ToString();
        SaveShips(s);
    }
    #endregion
    //-----------------------------------
    #region Private Methods
    private void Awake()
    {
       //int rand = Random.Range(0, 9);
       //PlayerPrefs.SetInt(currentShipRepo, (int)ShipEnums.Red1); //insted of "3" I wrote "ShipeEnums.Red1"
       //PlayerPrefs.SetInt(currentShipRepo, rand);
       Init();
    }
    private void Init()
    {
        if(PlayerPrefs.HasKey(shipsRepos) == false)
        {
            SetCurrentShip(0);
            string s = "0";
            SaveShips(s);
        }
    }
    private void SaveShips(string s)
    {
        PlayerPrefs.SetString(shipsRepos,s);
    }
    private string RetriveShips()
    {
        return PlayerPrefs.GetString(shipsRepos);
    }
    private bool IsShipActive(int i)
    {
        string s = PlayerPrefs.GetString(shipsRepos);
        if (s.Contains(i.ToString()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}
