using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region singleton

    public static GameController instance = null;

    public static GameController Instance
    {
        get
        { 
            return instance; 
        }
    }
    #endregion

    #region Variables
    public Transform playerSpawn;

    public GameObject player;
    public GameObject playerCorpse;

    public float remainingTime;
    public float maxTime;

    private bool _isRunActive = true;
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

    private void Start() 
    {
        remainingTime = maxTime;
    }
    private void Update() 
    {
        if(_isRunActive)
        {
            remainingTime -= Time.deltaTime;
            UIController.instance.UpdateCounter(remainingTime);
            if (remainingTime <= 0f)
            {
                _isRunActive = false;
                remainingTime = 0;
                StartCoroutine(StartNextRun());
            }
        }
    }


    public void AddTime(float value)
    {
        remainingTime += value;
        if(remainingTime > maxTime) remainingTime = maxTime;
    }

    IEnumerator StartNextRun()
    {
        UIController.instance.FadeToBlack(true);
        yield return new WaitForSeconds(1f);
        GameObject lastRobot = Instantiate(playerCorpse, player.transform.position, player.transform.rotation);
        lastRobot.GetComponent<Battery>().batteryValue = remainingTime;
        yield return new WaitForSeconds(2f);
        remainingTime = maxTime;
        player.transform.position = playerSpawn.position;
        UIController.instance.FadeToBlack(false);
        _isRunActive = true;
        
    }
}
