using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLog : MonoBehaviour
{
    #region Public VAriables
    public int bulletShots;
    public int bulletOutOfBound;
    public int bulletOnTarget;
    public int asteroidDestroyed;
    public int asteroidCrossed;
    public int unitEnemyShipDestroyed;
    public int unitEnemyShipCrossed;
    public int motherEnemyShipDestroyed;
    public int motherEnemyShipCrossed;
    public int coins;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void Addbullet()
    {
        bulletShots += 1 ;
    }
    public void AddBulletOnTarget()
    {
        bulletOnTarget += 1;
    }
    public void AddBulletOutOfBounds()
    {
        bulletOutOfBound += 1 ;
    }
    public void AddAsteroidDestroyed()
    {
        asteroidDestroyed += 1 ;
    }
    public void AddAsteroidCrossed()
    {
        asteroidCrossed += 1 ;
    }
    public void AddUnitEnemyShipCrossed()
    {
        unitEnemyShipCrossed += 1;
    }
    public void AddUnitEnemyShipDestroyed()
    {
        unitEnemyShipDestroyed += 1 ;
    }   
    public void AddUnitMotherShipDestroyed()
    {
        motherEnemyShipDestroyed += 1 ;
    }
    public void AddUnitMotherShipCrossed()
    {
        motherEnemyShipCrossed += 1;
    }
    public void AddCoin()
    {
        coins += 1 ;
    }
    #endregion

    #region Private Methods
    #endregion
}
