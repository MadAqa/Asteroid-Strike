using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidsSpawner : MonoBehaviour
{
    #region Public Variables
    public GameObject[] astroidsPrefab;
    public Vector2 timeToSpawn;
    public Vector2 xAxisLimitToSpawn;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methodes
    #endregion

    #region Private Methodes
    private void Start()
    {
        StartCoroutine(Spawn());
        //Invoke("Spawn", Random.Range(timeToSpawn.x, timeToSpawn.y));
    }
    /*private void Spawn()
    {
        Instantiate(astroidPrefab, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(timeToSpawn.x, timeToSpawn.y));
    } */
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x, timeToSpawn.y));

        Vector3 pos = transform.position;
        pos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);// this and the line before is for make the astroids spawn between X and Y distance

        int rand= Random.Range(0, astroidsPrefab.Length);// random number for astroid prefabs, randomly apear
        Instantiate(astroidsPrefab[rand], pos, Quaternion.identity);
        StartCoroutine(Spawn());
    }

    #endregion
}
