using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EnemyLifeUI : MonoBehaviour
{
    public Image EnemyLifeBar;
    public Enemy enemy;

    void Start()
    {

    }


    void Update()
    {

        int MaxHealth = enemy.maxHealth;
        int CurrentHealth = enemy.currentHealth;

        float RemainingHealth = (float)CurrentHealth / (float)MaxHealth;
        EnemyLifeBar.fillAmount = RemainingHealth;

        //LifeBar.fillAmount = -playerMovement.currentHealth + playerMovement.maxHealth;
    }
}
