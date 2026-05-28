using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class wavespawn : MonoBehaviour
{
    //public GameObject trigSpawn;
    public List<GameObject> zomSpwanPoints = new List<GameObject>();
    public List<GameObject> chickSpwanPoints = new List<GameObject>();
    public int enemySpawn = 1;
    public int currentWave = 0;
    public GameObject zombiePrefab;
    public GameObject pressEKey;
    //private bool isKeyPressed = false;
    private bool playerInTrig = false;
    private UiManager uiManager;
    private CollectableSpawner zero;
    private CollectableSpawner one;
    private CollectableSpawner two;
    private List<CollectableSpawner> spawners = new List<CollectableSpawner>();
    public wavespawn instance;
    public bool isWaveActive = false;

    void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>();

            GameObject[] j = GameObject.FindGameObjectsWithTag("CollectableSpawner");
             zero = j[0].GetComponent<CollectableSpawner>();
             one = j[1].GetComponent<CollectableSpawner>();
             two = j[2].GetComponent<CollectableSpawner>();
        
        instance = this;
        
        }

        public void CheckWaveActive()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length >= 1) 
        {
            isWaveActive = true;
        }
        else
        {
            isWaveActive = false;
        };
    }
    void Update()
    {
        
        //Debug.Log(isWaveActive);

        if (playerInTrig && Keyboard.current.eKey.wasPressedThisFrame)
        {   
            CheckWaveActive();
            if(isWaveActive == false)
            {
            Audio.instance.PlayGhostBreath();
            zero.SpawnEnlessMode();
            one.SpawnEnlessMode();
            two.SpawnEnlessMode();
            enemySpawn = 1;
            enemySpawn += currentWave;
            currentWave++;
            uiManager.CurrentWave(currentWave);
            
            for(int j = 0; j < enemySpawn ; j++){
            foreach (GameObject i in zomSpwanPoints)
            {
                Instantiate(zombiePrefab, i.transform.position, i.transform.rotation);
                
            }
            }
        }}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrig = true;
            pressEKey.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrig = false;
            pressEKey.SetActive(false);
        }
    }


}
