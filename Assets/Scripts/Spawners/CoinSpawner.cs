using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    #region public Variables
    public Vector2 coinsToSpawn;
    public GameObject coinPrefab;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Start()
    {
        int countOfCoinsToSpawn = (int) Random.Range(coinsToSpawn.x, coinsToSpawn.y);
        for(int i = 0; i < countOfCoinsToSpawn; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    #endregion
}
