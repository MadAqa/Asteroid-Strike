using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    #region Public Variables
    public float vSpeed; // vertical speed
    public float hSpeed; //horizontal speed
    public GameObject bulletPrefab;
    public Vector2 timeToFire;
    public GameObject gun;
    public int power;
    public GameObject firePrefab;

    #endregion

    #region Private Variables
    private int direction = 0; // 1 => right , -1 => left , 0 => steady
    private GameController gameController;
    private int initPower;
    #endregion

    #region Public Methodes
    #endregion

    #region Privete Methodes
    private void Start()
    {
        initPower = power;
        gameController = GameObject.FindObjectOfType<GameController>();
        InvokeRepeating("ChangeDirection", 1, 0.5f);
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
    }
    private void Update()
    {

        Vector3 move = Vector3.down;
        move.x = direction * hSpeed;
        move.y = move.y * vSpeed;
        transform.position += move * Time.deltaTime;
        checkSpaceShipOutOfBounds();
    }
    private void checkSpaceShipOutOfBounds()
    {
        Vector3 pos= transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -6, 6);
        transform.position = pos;
    }
    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2); //(-1,0,1)
    }
    private void Fire()
    {
        Instantiate(bulletPrefab,gun.transform.position, Quaternion.identity);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        power = power - collision.gameObject.GetComponent<BulletController>().power;
        CheckPower();
    }
    private void CheckPower()
    {
        if(power <= 0)
        {
            gameController.AddScore(initPower);
            gameController.AddDestroyedItems(gameObject.tag);
            Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    #endregion


}

