using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    #region Public Variables
    public Vector3 speed;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
    #endregion
}
