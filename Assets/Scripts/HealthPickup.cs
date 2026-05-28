using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPickup : MonoBehaviour
{
    private bool isInside;
    private UiManager ui;
    void Awake()
    {
         ui = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>();
    }
    void Update()
    {
        if (isInside && Keyboard.current.eKey.wasPressedThisFrame &&  GameManager.instance.money >= 20)
        {
            GameManager.instance.money -= 20;
            Health.instance.HealPlayer();
            ui.UpdateMoney();

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        ui.pressEKey.SetActive(true);
        isInside = true;
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        ui.pressEKey.SetActive(false);
        isInside = false;
    }
}
