using UnityEngine;

public class Collectable : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ghosts Collected!");
            Audio.instance.PlayPickup();
            GameManager.instance.collectable += 1 ;
            GameManager.instance.money += 1;
            PlayerPrefs.SetInt("collectable", PlayerPrefs.GetInt("collectable") + 1);
            UiManager.instance.UpdateScore();
            UiManager.instance.UpdateMoney();
            Destroy(gameObject);
        }
    }

}
