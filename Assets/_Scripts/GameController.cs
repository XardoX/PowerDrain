﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

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
            if(remainingTime <= 10f)
            {
                if (remainingTime <= 0f)
                {
                    _isRunActive = false;
                    remainingTime = 0;
                    Player.instance.StopPlayer(true);
                    StartCoroutine(StartNextRun());
                }
                Player.instance.SlowPlayer(true);
            } else Player.instance.SlowPlayer(false);
            
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
        Player.instance.DropItem();
        GameObject lastRobot = Instantiate(playerCorpse, player.transform.position + corpseOffset, player.transform.rotation);
        lastRobot.GetComponent<Battery>().batteryValue = maxTime*timePercent + remainingTime;
        yield return new WaitForSeconds(2f);
        remainingTime = maxTime;
        player.transform.position = playerSpawn.position;
        UIController.instance.FadeToBlack(false);
        _isRunActive = true;
        Player.instance.StopPlayer(false);
        
    }
}
