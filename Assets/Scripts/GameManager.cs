using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int collectable;
    public int chickSpawend;
    public int money;
    public int enemyKilled;
    public static GameManager instance;

    public void Awake()
    {
       
       money = PlayerPrefs.GetInt("Money", money);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }

    }

}
