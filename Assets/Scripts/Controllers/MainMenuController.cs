using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Public Variables
    #endregion

    #region Private variables
    #endregion

    #region Public Methods
    public void StartGame()
    {
        SceneManager.LoadScene("Level 01");
    }
    public void ShipShop()
    {
        SceneManager.LoadScene("ShipShop");
    }
    public void OpenLevelManager()
    {
        SceneManager.LoadScene("LevelManager");
    }
    #endregion

    #region Privat Methods
    #endregion
}
