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
    [ReorderableList]
    public Objective[] objectives;
    private UIController uiController;
    private int _servers=0;
    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Debug.Log("Objective wyjebało");
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad(this.gameObject);
         
    }
    private void Start() {
        uiController = UIController.instance;
    }


    public void SetObjective(int id)
    {
        if(objectives[id].done == false)
        {
            uiController.objectiveText.text = objectives[id].objectiveText;
            objectives[id].done = true;
        } else if(objectives[id].done == false && objectives[id-1].done == true)
        {
            uiController.objectiveText.text = objectives[id].objectiveText;
            objectives[id].done = true;
        }
    }

    public void ClearObjective()
    {
        uiController.objectiveText.text = "";
    }

    public void UploadServer()
    {
        _servers++;
        if(_servers >= 3)
        {
            SetObjective(7);
        } else uiController.objectiveText.text = objectives[6].objectiveText +" "+_servers +"/3";
    }
}
[System.Serializable]
public class Objective 
{
    [ReadOnly]
    public bool done;
    [ResizableTextArea]
    public string objectiveText;
}
