using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    #region public variables
    public GameObject joyStickButtons;
    public GameObject fireButton;
    #endregion
    //----------------------------
    #region private variables
    private ShipController ship;
    #endregion
    //----------------------------
    #region pulbic Methods
    public void Fire()
    {
        ship.FireBullet();
    }
    public void MoveLeft()
    {
        ship.MoveLeft();
    }
    public void MoveRight()
    {
        ship.MoveRight();
    }
    public void MoveUp()
    { 
        ship.MoveUP();
    }
    public void MoveDown() 
    {
        ship.MoveDown();
    }
    public void StopMoving()
    {
        ship.StopMoving();
    }
    public void Attach(ShipController s)
    {
        ship = s;
        GUIActivator(true);

    }
    public void Dettach()
    {
        ship = null;
        GUIActivator(false);

    }

    #endregion
    //----------------------------
    #region private Methods
    private void GUIActivator(bool active)
    {
        joyStickButtons.gameObject.SetActive(active);
        fireButton.SetActive(active);
    }
    private void Start()
    {
        if(ship == null) // this is instead of the LateUpdate code and it's better
        {
            GUIActivator(false);
        }
    }
    /* private void LateUpdate()
    {
        if (ship == null)
        {
            joyStickButtons.gameObject.SetActive(false);
            fireButton.SetActive(false);
            ship= GameObject.FindObjectOfType<ShipController>();
        }
        else
        {
            joyStickButtons.gameObject.SetActive(true);
            fireButton.SetActive(true);
        }
    } */
    #endregion
}
