using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;
    public GameObject coinSpawner;
    public Sprite[] healthSprite; //this is for adding the health to every astroid that have health 
    #endregion

    #region Private Variables
    private const string ANIMATION_NAME = "health"; // this health is the one in the animation, not the one in the public class.
    private Animator anim;
    private SpriteRenderer spRender;
    private GameController gameController;
    private int initHealth;
    #endregion

    #region Public Methodes
    #endregion

    #region Private Methodes
    private void Awake()
    {
        initHealth = health; // this is for getting the total health without decreasing

        anim = GetComponent<Animator>();
        spRender = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime ;//Move downward

        transform.Rotate(Vector3.forward , rotationSpeed * Time.deltaTime);//this is for rotation P.S: "vector3.forward" means "new vector3(0,0,1)"

        
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        //  health = health - col.gameObject.GetComponent<BulletController>().power; //this is for collision between bullets and anstroids 
        if (col.gameObject.tag == "bullet_Player")
        {
            health = health - col.gameObject.GetComponent<BulletController>().power; //this is for collision between bullets and anstroids
        }
        else if(col.gameObject.tag == "Player")
        {
            // health = health - col.gameObject.GetComponent<ShipController>().InitHealth; //this is for collision between bullets and anstroids
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        CheckHealth();

    }
    private void CheckHealth() //this is for destroying astroids when their health become less than 1, with or without animator
    {
        if (health <= 0) {
            gameController.AddScore(initHealth);
            gameController.AddDestroyedItems(gameObject.tag);
            int rnd = Random.Range(1, 4);
            if (rnd % 2 == 0)
            {
                Instantiate(coinSpawner, transform.position, Quaternion.identity);
            }

            Instantiate(explosionPrefab, transform.position,Quaternion.identity) ;
            Destroy(gameObject); 
            }
        else
        {
            DoAnimationOrChangeSprite() ; 
        }
    }
    private void DoAnimationOrChangeSprite()
    {
        if(anim != null) //this is for the ones that we used animator
        {
            anim.SetInteger(ANIMATION_NAME, health);
        }
        else //this is for the ones that we didn't use animator
        {
            ChangeSprite();
        }
    }
    private void ChangeSprite() // when we add health to astroid, the last sprite is the first one we see because it have the same health as sprite
    {
        spRender.sprite = healthSprite[health - 1];
    }

    #endregion


}
