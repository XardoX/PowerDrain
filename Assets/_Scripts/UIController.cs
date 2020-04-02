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
    public TextMeshProUGUI interactText;
    #endregion

    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad(this.gameObject);
    }

    public void UpdateCounter(float timeLeft)
    {
        timeLeftCounter.text = timeLeft.ToString("F0");
    }

    public void ShowInteractPopUp(bool show, string t)
    {
        interactText.gameObject.SetActive(show);
        interactText.text = t;
    }
}
