using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private GameLog gameLog;
    [SerializeField]
    private GameController gameController;

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Update()
    {
        if (gameLog.coins > 20 && gameLog.asteroidDestroyed >=10)
        {
            gameController.Win();
        }
    }
    #endregion
}
