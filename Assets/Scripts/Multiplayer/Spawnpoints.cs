using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawnpoints : MonoBehaviour {

    public Transform hostSpawnPoint;
    public Transform clientSpawnPoint; 
    public GameObject playerPrefab; 
    public Button hostButton; 
    public Button clientButton; 

    void Start() {
        hostButton.onClick.AddListener(SpawnHost);

      
        clientButton.onClick.AddListener(SpawnClient);
    }

    void SpawnHost() {
    
        Instantiate(playerPrefab, hostSpawnPoint.position, Quaternion.identity);
    }

    void SpawnClient() {
       
        Instantiate(playerPrefab, clientSpawnPoint.position, Quaternion.identity);
    }
}
