using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldPickup : MonoBehaviour
{
    private bool isInside;
    public static ShieldPickup instance;
    private UiManager ui;
    public bool isShieldActive = false;
    void Awake()
    {
         ui = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>();
         instance = this;
    }

    void Update()
    {
        if (isShieldActive == false && isInside && Keyboard.current.eKey.wasPressedThisFrame &&  GameManager.instance.money >= 50)
        {   
            isShieldActive = true;
            Audio.instance.PlayShieldBreak(); // pickup & break same sound
            GameManager.instance.money -= 50;
            Health.instance.ShieldInit();
            ui.UpdateMoney();

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        ui.pressEKeyShield.SetActive(true);
        isInside = true;
    }
    void OnTriggerExit(Collider other)
    {   
        if(other.CompareTag("Player"))
        ui.pressEKeyShield.SetActive(false);
        isInside = false;
    }
}
