using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float playerHealth = 100f;
    public float playerShield = 0f;
    public bool isShieldActive = false;
    public float enemyHealth = 100f;
    private GameObject playerObj;
    public GameObject shieldObject;
    public static Health instance;
    private UiManager uiManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        uiManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>();

    }

    public void ShieldInit()
    {
        isShieldActive = true;
        UiManager.instance.shield.enabled = true;
        shieldObject.SetActive(true);
        playerShield = playerHealth * 2;
        UiManager.instance.shield.text = "Shield: " + playerShield;
        StartCoroutine(ShieldActiveTime());
    }

    public void HealPlayer()
    {
        playerHealth += 30;
        UiManager.instance.UpdateHealth();
    }

    public void HurtPlayerShield(int hurtAmount)
    {
        Audio.instance.PlayDemonAttack();
        playerShield -= hurtAmount;
        UiManager.instance.UpdateShield();
        if (playerShield <= 0)
        {
            Audio.instance.PlayShieldBreak();
            Debug.Log("Shield Broken");
            isShieldActive = false;
            shieldObject.SetActive(false);
            ShieldPickup.instance.isShieldActive = false;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //SceneManager.LoadScene("GameOver");
        }
    }

    public void HurtPlayer(int hurtAmount)
    {
        Audio.instance.PlayDemonAttack();
        playerHealth -= hurtAmount;
        UiManager.instance.UpdateHealth();
        if (playerHealth <= 0)
        {
            Audio.instance.PlayPlayerDie();
            Debug.Log("Player Killed!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
    }
    public void HurtEnemy(int hurtAmount)
    {
        enemyHealth -= hurtAmount;
        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy Killed!");
            Audio.instance.PlayDemonDie();
            GameManager.instance.enemyKilled += 1;
            PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled") + 1);
            uiManager.UpdateScore();
            Destroy(gameObject);
        }
    }

    IEnumerator ShieldActiveTime()
    {
        yield return new WaitForSeconds(30f);
        if(isShieldActive == true)  // if not broken by enemy
        {
            Audio.instance.PlayShieldBreak();
        }
        isShieldActive = false;
        shieldObject.SetActive(false);
        ShieldPickup.instance.isShieldActive = false;
        UiManager.instance.shield.enabled = false;
    }

}
