using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrollings : MonoBehaviour
{
    #region public Variables
    public Vector2 speed; //vector2 is because it have x&y axis

    #endregion

    #region private Variables
    private Renderer myRender;
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Awake()
    {
        myRender = GetComponent<Renderer>(); 
    }
    private void Update()
    {
        myRender.material.mainTextureOffset = Time.time * speed;
    }
    #endregion
}
