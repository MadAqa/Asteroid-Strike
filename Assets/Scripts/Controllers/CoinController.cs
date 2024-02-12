using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinController : MonoBehaviour
{
    #region public Variables
    public float speed;
    public AudioClip[] clips;
    public AudioSource audioSource;
    #endregion

    #region private Variables
    private AudioClip clip;
    private Vector2 direction;
    #endregion

    #region public Methods
    public void DestroyIt()
    {
        StartCoroutine(DestroyAfterSound()); //or Invoke("", clip.length);
    }
    #endregion

    #region private Methods
    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }
    private void Start()
    {
        clip =clips[ Random.Range(0,clips.Length)];
        audioSource.PlayOneShot(clip);
        direction = Vector2.up;
        direction.x = Random.Range(-1.5f, 1.5f);
        Invoke("GoDown", 0.5f);
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        CheckSpaceShipOutOfBounds();
    }
    private void GoDown()
    {
        direction.y *= -1;
        direction.x = Random.Range(-0.5f, 0.5f); ;
    }
    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -7.24f, 7.24f),
                   // Mathf.Clamp(transform.position.y, -4.24f, 3.31f),
                   transform.position.y,
                   transform.position.z
                    );

        if (transform.position.y < -5f) { Destroy(gameObject); }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            clip = clips[Random.Range(0, clips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
    #endregion
}
