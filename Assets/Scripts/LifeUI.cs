using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image LifeBar;
    public PlayerConfig playerConfig;

    void Start()
    {

    }


    void Update()
    {

        int MaxHealth = playerConfig.maxHealth;
        int CurrentHealth = playerConfig.currentHealth;

        float RemainingHealth = (float)CurrentHealth / (float)MaxHealth;
        LifeBar.fillAmount = RemainingHealth;

        //LifeBar.fillAmount = -playerMovement.currentHealth + playerMovement.maxHealth;
    }
}
