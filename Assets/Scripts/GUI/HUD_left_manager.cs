
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_left_manager : MonoBehaviour
{
    #region Public Variables
    public Text txtHealthPercent;
    public Text txtScore;
    public Sprite blueSprite, redSprite;
    public Image mainImage;
    public GameController gameController;

    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void SetScoreText(int score)
    {
        txtScore.text = score.ToString();
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Private Methods
    private void Start()
    {
        
        //txtScore.text = Random.Range(100, 3000).ToString();
    }
    private void LateUpdate()
    {
        int healthPercent = gameController.GetHealthPercent();
        txtHealthPercent.text = healthPercent.ToString();
        if (healthPercent > 60)
        {
            mainImage.sprite = blueSprite;
        }
        else
        {
            mainImage.sprite = redSprite;
        }
    }
    #endregion
}
