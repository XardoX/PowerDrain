﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
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

    public TextMeshProUGUI objectiveText;


    [Header("Blackscreen Settings")]
    public Image blackScreen;
    public Ease fadeInEase, fadeOutEase;
    public float fadeDuration;

    [Header("Warning Settings")]
    public TextMeshProUGUI batteryWarning;
    public Ease warningEase;
    public float targetAlpha = 0.8f;
    public float warningDuration = 1f;
    private Tween _warningTween;
    #endregion

    private void Awake() 
    {
         if (instance != null && instance != this) 
         {
             Debug.Log("UI wyjebało");
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad(this.gameObject);
         _warningTween = batteryWarning.DOFade(targetAlpha, warningDuration).SetLoops(-1, LoopType.Yoyo);
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

    public void FadeToBlack(bool fade)
    {
        if(fade)
        {
            blackScreen.DOFade(1f, fadeDuration).SetEase(fadeInEase);
        } else
        {
            blackScreen.DOFade(0f, fadeDuration).SetEase(fadeOutEase);
        }
    }

    public void BatteryWarning(bool warning)
    {
        if(warning)
        {
            batteryWarning.enabled = true;
            _warningTween.Play();
        }
        else 
        {
            batteryWarning.enabled = false;
            _warningTween.Pause();
        }
    }
}
