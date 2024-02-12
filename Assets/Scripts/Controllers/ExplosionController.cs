using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private Animator anim;
    #endregion

    #region Public Methodes
    #endregion

    #region Private Methodes
    private void Start()
    {
        //anim = GetComponent<Animator>();
        StartCoroutine(DestroyThis());
    }
    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
    #endregion
}