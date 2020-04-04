using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ObjectiveController : MonoBehaviour
{
    #region singleton
    public static ObjectiveController instance = null;

    public static ObjectiveController Instance
    {
        get
        { 
            return instance; 
        }
    }
    #endregion
    public Objective[] objectives;
    private UIController uiController;
    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad(this.gameObject);
         uiController = UIController.instance;
    }


    public void SetObjective(int id)
    {
        if(objectives[id].done == false)
        {
            uiController.objectiveText.text = objectives[id].objectiveText;
            objectives[id].done = true;
        }
    }

    public void ClearObjective()
    {
        uiController.objectiveText.text = "";
    }
}
[System.Serializable]
public class Objective 
{
    [ResizableTextArea]
    public string objectiveText;
    [HideInInspector]
    public bool done;
}
