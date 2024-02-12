using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_Bullet_manager : MonoBehaviour
{
    #region Public Variables
    public int dangerBulletCount;

    public Sprite blueSprite, redSprite;
    public Image mainHud;
    public Text txtBullet;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void SetBullet(int bullet)
    {
        txtBullet.text =bullet.ToString();

        if (bullet>= dangerBulletCount)// this is for bullet theme to be blue or red
        {
            mainHud.sprite = blueSprite;
        }
        else
        {
            mainHud.sprite = redSprite;
        }
    }
    public void Deachtive()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Private Methods
    private void Start()
    {
       //xtBullet.text = Random.Range(20, 50).ToString();
    }

    #endregion
}