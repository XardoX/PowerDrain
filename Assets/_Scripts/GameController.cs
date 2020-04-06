using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

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
    public Vector3 corpseOffset;

    public float remainingTime;
    public float maxTime;
    [Range(0f,1f)]
    public float timePercent = 0.2f;

    private bool _isRunActive = true;
    #endregion

    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Debug.Log("Game Controller wyjebało");
             Destroy(this.gameObject);
         }
 
         instance = this;
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

            
            if(remainingTime <= 10f)
            {
                if (remainingTime <= 0f)
                {
                    StartCoroutine(StartNextRun());
                }
                UIController.instance.BatteryWarning(true);
                Player.instance.SlowPlayer(true);
            } else 
            {
                Player.instance.SlowPlayer(false);
                UIController.instance.BatteryWarning(false);
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                UIController.instance.BatteryWarning(false);
                UIController.instance.SelfDestructWarning(true);
                StartCoroutine(SelfDestruct());
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

        _isRunActive = false;
        
        Player.instance.StopPlayer(true);
        UIController.instance.FadeToBlack(true);
        yield return new WaitForSeconds(1f);
        UIController.instance.BatteryWarning(false);
        Player.instance.DropItem();
        GameObject lastRobot = Instantiate(playerCorpse, player.transform.position + corpseOffset, player.transform.rotation);
        lastRobot.GetComponent<Battery>().batteryValue = maxTime*timePercent + remainingTime;
        remainingTime = 0;
        yield return new WaitForSeconds(2f);
        remainingTime = maxTime;
        player.transform.position = playerSpawn.position;
        player.transform.rotation = playerSpawn.rotation;
        UIController.instance.FadeToBlack(false);
        _isRunActive = true;
        Player.instance.StopPlayer(false);
        Player.instance.SlowPlayer(false);
    }

    IEnumerator SelfDestruct()
    {
        _isRunActive = false;
        Player.instance.SlowPlayer(true);
        UIController.instance.BatteryWarning(false);
        yield return new WaitForSeconds(2f);
        Player.instance.StopPlayer(true);
        UIController.instance.FadeToBlack(true);
        yield return new WaitForSeconds(1f);
        UIController.instance.SelfDestructWarning(false);
        Player.instance.DropItem();
        GameObject lastRobot = Instantiate(playerCorpse, player.transform.position + corpseOffset, player.transform.rotation);
        lastRobot.GetComponent<Battery>().batteryValue = maxTime*timePercent + remainingTime;
        remainingTime = 0;
        yield return new WaitForSeconds(2f);
        remainingTime = maxTime;
        player.transform.position = playerSpawn.position;
        player.transform.rotation = playerSpawn.rotation;
        UIController.instance.FadeToBlack(false);
        _isRunActive = true;
        Player.instance.StopPlayer(false);
        
    }
    [Button]
    public void EndGame()
    {
        _isRunActive = false;
        Player.instance.StopPlayer(true);
        UIController.instance.ShowEndScreen();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Design");
    }
}
