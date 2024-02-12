using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletDirection
{
    UP, DOWN
}
public class BulletController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public BulletDirection direction;
    public GameObject explosionPrefab;
    public int power;
    public Sprite[] sprites;
    #endregion

    #region Private Variables
    private Vector3 move = Vector3.down;
    [SerializeField]
    private SpriteRenderer spRender;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        spRender.sprite = sprites[Random.Range(0, sprites.Length - 1)];// to create random bullet's color
        if (direction == BulletDirection.DOWN) {
        move= Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
    }
    private void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(explosionPrefab, col.contacts[0].point, Quaternion.identity);
        //Destroy(col.gameObject); we added health to the astroids and because of that this part became unUseable
        Destroy(gameObject);

    }
    #endregion

}
