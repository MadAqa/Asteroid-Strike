using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGameOverPanelManager : MonoBehaviour
{
    #region public Variables
    public Text txtEndMessage;
    public Text txtScore;
    public Text txtAccuracy;
    public Text txtDestroyed;
    public Text txtCoin;
    public GameObject btnReply;
    public GameObject btnNextLevel;
    public AudioClip startClip;
    public AudioClip btnReplayClip, btnMainMenuClip;
    #endregion
    //--------------------------------------------------
    #region private Variables
    [SerializeField]
    private AudioSource audioSource;
    #endregion
    //--------------------------------------------------
    #region private const Variables
    private string winMessage = "YOU WON !";
    private string gameOverMessage = "GAME OVER..";
    #endregion
    //--------------------------------------------------
    #region public Methods
    public void Init(bool isWin, int score, int accuracy, int destroyed, int coins)
    {
        SetWinMessage(isWin);
        SetButtons(isWin);
        txtScore.text = score.ToString();
        txtAccuracy.text = accuracy.ToString()+ " %";
        txtDestroyed.text = destroyed.ToString();
        txtCoin.text = coins.ToString();
        audioSource.PlayOneShot(startClip);
    }
    public void ReplayGame() 
    {
        audioSource.PlayOneShot(btnReplayClip);
        Invoke("ReplayGameAfterSound", btnReplayClip.length);
        //Application.LoadLevel(0); || Application.LoadLevel(Application.loadedLevel); || Application.LoadLevel("Level 01); these are old ways but still works.
    }
    public void MaiMenu()
    {
        
        audioSource.PlayOneShot(btnMainMenuClip);
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
    //--------------------------------------------------
    #region private Methods
    private void ReplayGameAfterSound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // to do this, we must add -> "using UnityEngine.SceneManagement;"
    }
    private void SetWinMessage(bool isWin)
    {
        if (isWin == true)
        {
        txtEndMessage.text = winMessage;
        }
        else
        {
            txtEndMessage.text = gameOverMessage;
        }
    }
    private void SetButtons(bool isWin)
    {
        if(isWin)
        {
            btnReply.SetActive(false);
            btnNextLevel.SetActive(true);
        }
        else
        {
            btnReply.SetActive(true);
            btnNextLevel.SetActive(false);
        }
    }
    #endregion
}
