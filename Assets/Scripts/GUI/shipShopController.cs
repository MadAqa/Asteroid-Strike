using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shipShopController : MonoBehaviour
{
    #region Public Variables
    public Text txtModel, txtGuntype, txtPrice, txtCoins;
    public GameObject pnlSpeed, pnlHealth, pnlFireRate, pnlGunCount, pnlBulletPower, btnSelect, btnBuy, btnAddCoins ;
    public Image shipSprite;
    public LockController lockController;
    [Header("Repositorys")]
    public CoinRepository coinRepo;
    public ShipRepository shipRepository;
    
    #endregion

    #region Private Variabels
    private ShipStruct currentShip;
    private int i = 0;
    #endregion

    #region Public 
    public void NextShip()
    {
        i = i + 1;

            if (i >= shipRepository.shipsCount)
            {
            i = 0;
            }

        currentShip = shipRepository.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    public void PrevShip() 
    { 
        i = i - 1;

            if (i < 0)
            {
            i = shipRepository.shipsCount - 1;
            }

        currentShip = shipRepository.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    public void SelectShip()
    {
        shipRepository.SetCurrentShip((int)currentShip.key);
    }
    #endregion
    public void BuyShip()
    {
        if (coinRepo.Pop(currentShip.price))
        {
            shipRepository.ActiveNewShip((int)currentShip.key);
            UpdateButtons(false, currentShip.price,coinRepo.Get());
            UpdateCoin();
        }
    }
    public void AddCoin()
    {
        coinRepo.Push(200);
        UpdateCoin();
        UpdateButtons(currentShip.isLocked,currentShip.price,coinRepo.Get());
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #region Private Methods
    private void Start()
    {
        UpdateCoin();
        i = 0;
        currentShip = shipRepository.GetShipByIndex(i);
        UpdateInformation(currentShip);
       // Debug.Log("coins:" + coinRepo.Get().ToString());
    }
    private void UpdateCoin()
    {
        txtCoins.text = coinRepo.Get().ToString();
        currentShip = shipRepository.GetCurrentShip();
        UpdateInformation(currentShip);
    }
    private void UpdateInformation(ShipStruct ship)
    {
        txtModel.text = ship.model;
        shipSprite.sprite = ship.sprite;
        txtGuntype.text = ship.bulletType.ToString();
       /* switch (ship.bulletType) // this wasn't good way to do this (my correction) 
        {
            case BulletType.Bomb:
                txtGuntype.text = "BOMB";
                break;
            case BulletType.Rocket:
                txtGuntype.text = "ROCKET";
                break;
            case BulletType.Laser:
                txtGuntype.text = "LASER";
                break;
        } */
        SetPrice(ship.price); // calling the class for ship price
        InitializeBars(pnlHealth, ship.health);
        InitializeBars(pnlSpeed,ship.speed);
        InitializeBars(pnlFireRate,(int)(ship.fireRate*10));
        InitializeBars(pnlGunCount,ship.guns);
        InitializeBars(pnlBulletPower,ship.bulletPower);
        UpdateButtons(ship.isLocked, ship.price, coinRepo.Get());
        lockController.SetStatus(ship.isLocked);
    }
    private void UpdateButtons(bool isLocked, int price , int coins) 
    {
        btnSelect.gameObject.SetActive(false);
        btnBuy.gameObject.SetActive(false);
        btnAddCoins.gameObject.SetActive(false);
        if(isLocked == true && coins >= price) 
        {
        btnBuy.gameObject.SetActive(true);
        }
        else if(isLocked == true && coins < price)
        {
            btnAddCoins.gameObject.SetActive(true) ;
        }else if(isLocked == false)
        {
            btnSelect.gameObject.SetActive(true ) ;
        }

    }  
    private void SetPrice(int price)
    {
        if (price == 0)
        {
            txtPrice.text = "FREE";
        }
        else
        {
            txtPrice.text = price.ToString();
        }
    }
    private void InitializeBars(GameObject panel,int count)
    {
        int childCount = panel.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            RadiobuttonManager child = panel.transform.GetChild(i).GetComponent<RadiobuttonManager>();
            if(i < count)
            {
                child.Enable();
            }
            else {
                child.Disable();
            }
        }
    }
    #endregion
}
