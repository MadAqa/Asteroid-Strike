using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonLevelController : MonoBehaviour
{
    #region Public Vaeriables
    public Image lockImage;
    public Text txtLevelNum;
    #endregion

    #region Private Variables
    private bool isOpen;
    private int number;
    #endregion

    #region Public Methods
    public void Init(int num,bool open)
    {
        isOpen = open;
        if(isOpen)
        {
            txtLevelNum.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
            txtLevelNum.text = (num + 1).ToString();
            number = num;
        }
        else
        {
            txtLevelNum.gameObject.SetActive(false);
            lockImage.gameObject.SetActive(true);
        }
    }
    public void Click()
    {
        if(isOpen)
        {
            string sceneName = "Level " + number; //if number =5, level 5 opens
            SceneManager.LoadScene(sceneName);
        }
    }
    #endregion

    #region Private Methods
    
    #endregion
}
