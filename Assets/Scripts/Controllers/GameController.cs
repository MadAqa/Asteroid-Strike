using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Public Variables
    public int Score { get { return score; }}
    public HUD_left_manager hudTopLeftManager;
    public HUD_Bullet_manager hudBulletManager;
    public GameObject pauseButton;
    public CoinRepository coinRepo;
    public ScoreRepository scoreRepo;
    public ShipRepository shipRepos;
    public JoyStick joyStick;
    public WinGameOverPanelManager winGameOverPanel;
    public LevelRepository levelRepo;
    public GameLog gameLog;
    #endregion
    //--------------------------
    #region Private Variables
    private int score; // player score
    private int bullet = 100; //this is for number of bullets
    private int coins = 0;
    private int destroyedItems =0; //number of destroyed items in this level
    private ShipStruct ship;
    private int bulletOutOfBounds = 0;
    ShipController shipController;
    #endregion
    //--------------------------
    #region Public Methods
    public int GetHealthPercent()//!!!!!!!!!!!!!!!!!
    {
        return shipController.GetHealthPercent();
    }
    public void Win()
    {
        if (winGameOverPanel.gameObject.activeInHierarchy == false)
                 {
            levelRepo.OpenNextLevel();            
            joyStick.Dettach();//this is method from "JoyStick.cs" and diactivates joystick
            hudBulletManager.Deachtive();
            hudTopLeftManager.Deactive();
            pauseButton.SetActive(false);
            winGameOverPanel.gameObject.SetActive(true);// this is to show this panel after gameOver
            winGameOverPanel.Init(true, score, GetBulletsOnTargetPercent(shipController.GetBulletFired()), destroyedItems, coins);
        }
        // winGameOverPanel.Init(true);

    }
    public void GameOver(int numOfBullets) 
    {
        joyStick.Dettach();//this is method from "JoyStick.cs" and diactivates joystick
        hudBulletManager.Deachtive();
        hudTopLeftManager.Deactive();
        pauseButton.SetActive(false);

        winGameOverPanel.gameObject.SetActive(true);// this is to show this panel after gameOver
        winGameOverPanel.Init(false,score,GetBulletsOnTargetPercent(numOfBullets),destroyedItems,coins);
    }
    public void GameObjectDeactivator(GameObject ob)
    {
        if(ob.tag == "bullet_Player")
        {
            bulletOutOfBounds += 1;
            gameLog.AddBulletOutOfBounds();
        }
        Destroy(ob.gameObject);
    }
    public void AddScore(int s)
    {
        if (s > 0) { 
            score += s;
            hudTopLeftManager.SetScoreText(score);
        }
    }
    public bool HasBullet()
    {
        if (bullet > 0) return true;
        return false;
    }
    public void PopBullet()
    {
        bullet = bullet - 1;
        hudBulletManager.SetBullet(bullet);
    }
    public void AddCoin()
    {
        coins += 1; // coins = coins + 1;
        gameLog.AddCoin();
    }
    public void AddDestroyedItems(string tag)
    {
        if (tag == "asteroid")
        {
            gameLog.AddAsteroidDestroyed();
        }
        if(tag == "ship_enemy")
        {
            gameLog.AddUnitMotherShipDestroyed();
        }
        destroyedItems += 1;
    }

    #endregion
    //--------------------------
    #region Private Methods
    private void Start()
    {
        ship = shipRepos.GetCurrentShip();
        GameObject shipObject =(GameObject) Instantiate(ship.ship, Vector3.zero, Quaternion.identity);//make a ship in the screen and add it to the shipObject
        shipController = shipObject.GetComponent<ShipController>();
        shipController.Init(ship.speed, ship.fireRate, ship.health);//this is for adjusting ship parameters
        joyStick.Attach(shipController);
        // joyStick.Attach(shipObject.GetComponent<ShipController>());
        coins = 0;
        score = 0;
        bullet = 100;
        destroyedItems = 0;
        hudTopLeftManager.SetScoreText(score);
        hudBulletManager.SetBullet(bullet);
        //Debug.Log("last score:" + scoreRepo.GetLastScore() + "highscore:" + scoreRepo.GetHighScore());

        winGameOverPanel.gameObject.SetActive(false);//this is to hide the gameOver panel in game
    }

    private void Update()
    {
       //if(coins >= 5 && destroyedItems >= 5)
       // {
       //     if (winGameOverPanel.gameObject.activeInHierarchy == false)
       //     {
       //         Win();
       //     }
       // }
    }
    private void OnApplicationQuit()
    {

        //coins += PlayerPrefs.GetInt("coin");
        //PlayerPrefs.SetInt("coin", coins);
        coinRepo.Push(coins);
        scoreRepo.Push(score);
    }
    private int GetBulletsOnTargetPercent(int total)
    {
        float onTarget = total - bulletOutOfBounds;
        float per = (onTarget / total) * 100;
        int intPer = (int)per;
        return Mathf.Clamp(intPer,0,100);
    }
    #endregion
}
