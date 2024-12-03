using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Blood playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scroreKeeper;
    
    void Awake()
    {
        scroreKeeper = FindObjectOfType<ScoreKeeper>(); 
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update(){
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scroreKeeper.GetScore().ToString("0000");
    }

}
