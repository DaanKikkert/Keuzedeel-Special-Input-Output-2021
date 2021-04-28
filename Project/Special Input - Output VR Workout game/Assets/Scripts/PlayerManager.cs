using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] int playerHealth;
    [SerializeField] Text healthText;
    [SerializeField] PauseScript pauseScript;
    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHandL;
    [SerializeField] GameObject leftHandL;
    [SerializeField] GameObject PauseMenu;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        string scoreT = score.ToString();
        scoreText.text = scoreT;
        string HealthT = playerHealth.ToString();
        healthText.text = HealthT;

        if(playerHealth <= 0)
        {
            Death();
        }
    }

    public void scoreUp()
    {
        score++;
        Debug.Log(score);
    }

    public void TakeDamage()
    {
        playerHealth--;
        Debug.Log("HP: " + playerHealth);
    }

    public void Death()
    {
        pauseScript.PauseGame();
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach(GameObject target in targets)
        {
            GameObject.Destroy(target);
        }
        PauseMenu.SetActive(true);
        leftHandL.SetActive(true);
        rightHandL.SetActive(true);
        rightHand.SetActive(false);
        leftHand.SetActive(false);
    }
}
