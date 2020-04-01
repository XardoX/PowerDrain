using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    #region singleton
    public static UIController instance = null;

    public static UIController Instance
    {
        get
        { 
            return instance; 
        }
    }
    #endregion
   
    #region Variables
    public TextMeshProUGUI timeLeftCounter;

}
