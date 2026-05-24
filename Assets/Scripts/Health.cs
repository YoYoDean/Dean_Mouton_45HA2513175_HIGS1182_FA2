using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float playerHealth = 100f;
    public float enemyHealth = 100f;
    private GameObject playerObj;
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

    public void HealPlayer()
    {
        playerHealth += 30;
        UiManager.instance.UpdateHealth();
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

}
