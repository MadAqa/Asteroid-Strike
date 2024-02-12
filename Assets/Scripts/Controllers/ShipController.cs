using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region Public Variables
    
    public GameObject bulletPrefab;
    public GameObject[] guns;
    public int Health { get { return _health; } }
    public int InitHealth { get { return InitHealth; } } // this was a problem
    public Animator flameAnimator;
    
    #endregion
    //----------------------------------------------
    #region Private Variables
    private float fireRate = 0.3f;
    private float speed;
    [SerializeField]
    private int _health;
    private float lastShot = 0;
    private const string FLAME_ANIMATION = "speed";
    private float h, v;
    private GameController gameController; //refrence to the game controller
    private int numOfBullets = 0;
    private int initHealth;
    #endregion

    //----------------------------------------------
    #region Public Methods
    public int GetBulletFired()
    {
        return numOfBullets;
    }
    public void Init(float _speed,float _fireRate, int _h)
    {
        speed = _speed;
        fireRate = _fireRate;
        _health = _h;
        initHealth = _health;
    }
    public void FireBullet()
    {
        Fire();
    }
    public void MoveUP()
    {
        v = 1;
    }
    public void MoveRight()
    {
        h = 1;
    }
    public void MoveDown()
    {
        v = -1;
    }
    public void MoveLeft()
    {
        h = -1;
    }
    public void StopMoving()
    {
        v = 0;
        h = 0;
    }
    public int GetHealthPercent()
    {
         //this is wierd ?????????

        if (initHealth == _health) return 100;

        float remainHealth = initHealth - _health;
        float p = (remainHealth / initHealth) * 100;
        return (int)p;

    }
    #endregion
    //----------------------------------------------
    #region Private Methods
    // Start is called before the first frame update
    private void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        numOfBullets = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        // h = Input.GetAxis("Horizontal"); //this is for moving in horizontal axis
        //  v = Input.GetAxis("Vertical"); // this is for moving in vertical axis
        CheckKeyboardInput();

        // transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime; //transform.position += new Vector3(speed * h * Time.deltaTime, speed * v* Time.deltaTime, 0);
        Vector3 move = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position += move;
        /*   if we didn't want to use "sqrMagnitude" we could write the code like this.
          if(move.x >= 0.1f || move.y >= 0.1f)
         {
             flameAnimator.SetFloat("speed", 1);
         } ...
        */

        flameAnimator.SetFloat(FLAME_ANIMATION, move.sqrMagnitude);

        CheckSpaceShipOutOfBounds();

        if (Input.GetKeyDown(KeyCode.Space))// fire the bullet
        {
            Fire();
        }

    }

    private void CheckKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUP();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopMoving();
        }
    }

    private void Fire()
    {
        // 1,  0.3 + 0 = 0.3 then shot happens
        // 1, 0.3 + 1 = 1.3 then shot not happens
        if (Time.time > fireRate + lastShot && gameController.HasBullet())
        {
            for (int i = 0; i < guns.Length; i++)
            {
                numOfBullets += 1;
                Instantiate(bulletPrefab, guns[i].transform.position, Quaternion.identity);
                gameController.PopBullet();
            }
            lastShot = Time.time;
        }
    }

    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -7.24f, 7.24f),
                    Mathf.Clamp(transform.position.y, -4.24f, 3.31f),
                    transform.position.z
                    );

        /* if(transform.position.x < -7.24f) //this is for befor "mathf.clamp()" code.
         {
             Vector3 pose = transform.position;
             pose.x = -7.24f;
             transform.position = pose;  
         }
         if (transform.position.x > 7.24f)
         {
             Vector3 pose = transform.position;
             pose.x = 7.24f;
             transform.position = pose;
         }
         if (transform.position.y > 3.31f)
         {
             Vector3 pose = transform.position;
             pose.y = 3.31f;
             transform.position = pose;
         }
         if (transform.position.y < -4.24f)
         {
             Vector3 pose = transform.position;
             pose.y = -4.24f;
             transform.position = pose;
         }*/
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       if( col.gameObject.tag == "bullet_enemy")
        {
            _health -= col.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if( col.gameObject.tag == "asteroid")
        {
            _health -= col .gameObject.GetComponent<AsteroidController>().health;
            CheckHealth();
        }
        else if ( col.gameObject.tag == "ship_enemy")
        {
            _health = _health - col.gameObject.GetComponent<EnemyShipController>().power; //this is like the previous codes but in different way.
            CheckHealth();
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<CoinController>().DestroyIt();
            gameController.AddCoin();
        }
    }
    private void CheckHealth()
    {
        if(_health <= 0)
        {
            gameController.GameOver(numOfBullets);
            //todo : need improve
            Destroy(gameObject);
        }
    }
    #endregion



}
