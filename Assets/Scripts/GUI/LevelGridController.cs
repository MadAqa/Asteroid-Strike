using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGridController : MonoBehaviour
{
    #region Public Variables
    public GameObject btnLevelPrefab;
    #endregion

    #region Private Variables
    [SerializeField]
    private LevelRepository levelRepo;
    #endregion

    #region Pulbic Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        bool[] levels = levelRepo.RetriveAllLevels();
        for (int i = 0; i < levelRepo.levelCount; i++)
        {
            GameObject btn = Instantiate(btnLevelPrefab,transform.position,Quaternion.identity) as GameObject;
            btn.transform.SetParent(transform);
            btn.GetComponent<ButtonLevelController>().Init(i, levels[i]);
            btn.transform.localScale = Vector3.one;
        }
    }
    #endregion
}
