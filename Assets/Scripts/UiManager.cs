using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    
    public TextMeshProUGUI coll;
    public TextMeshProUGUI enemyKill;
    public TextMeshProUGUI health;
    public TextMeshProUGUI shield;
    public TextMeshProUGUI currWave;
    public TextMeshProUGUI money;
    public GameObject pressEKey;
    public GameObject pressEKeyShield;
    public static UiManager instance;
    public TextMeshProUGUI highMoney;
    public TextMeshProUGUI highZombie;
    public TextMeshProUGUI highColl;
    public TextMeshProUGUI highWaves;
    public TextMeshProUGUI tmrText;
    public wavespawn wavespawn;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
        
        if(SceneManager.GetActiveScene().name == "EndlessMode")
         {wavespawn = GameObject.FindGameObjectWithTag("wavespawn").GetComponent<wavespawn>();
            UpdateMoney();  
            shield.enabled = false;        
         }
        //Debug.Log("Check");
        if(SceneManager.GetActiveScene().name == "Start")
        {
        highMoney.text = "Money: " + PlayerPrefs.GetInt("Money");
        highColl.text = "Ghosts Collected: " + PlayerPrefs.GetInt("collectable");
        highZombie.text = "Demons Killed: " + PlayerPrefs.GetInt("EnemiesKilled");
        highWaves.text = "Waves Lasted: " + PlayerPrefs.GetInt("Waves");
        }
        

    }

    public void UpdateScore()
    {
        coll.text = "Ghosts Collected: " + GameManager.instance.collectable;
        enemyKill.text = "Demons Killed: " + GameManager.instance.enemyKilled;
        
    }
    public void UpdateMoney()
    {
        money.text = "Money: " + GameManager.instance.money;
        PlayerPrefs.SetInt("Money", GameManager.instance.money);
    }

    public void UpdateHealth()
    {
        health.text = "Health: " + Health.instance.playerHealth;
    }
    public void UpdateTimer(float tmr)
    {
    tmrText.text = "Shield Tmr: " + Mathf.CeilToInt(tmr);
    }

    public void UpdateShield()
    {
        shield.text = "Shield: " + Health.instance.playerShield;
    }
    public void CurrentWave(int value)
    {
        currWave.text = "Wave: " + value;
        if(value > PlayerPrefs.GetInt("Waves"))
        {
         PlayerPrefs.SetInt("Waves", wavespawn.instance.currentWave);   
        }
        
    }


}
