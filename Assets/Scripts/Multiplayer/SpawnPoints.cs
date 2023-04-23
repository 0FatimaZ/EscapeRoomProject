using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class SpawnPoints : NetworkBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsServer)
        {
            StartCoroutine(MovePlayersAfterDelay());
        }
    }

    IEnumerator MovePlayersAfterDelay()
    {
        yield return new WaitForSeconds(5.0f);

        // Move the host to spawn point 2
        if (NetworkManager.Singleton.IsServer && IsServer)
        {
            transform.position = spawnPoint2.position;
        }

        // Move the client to spawn point 1
        if (NetworkManager.Singleton.IsClient && IsClient)
        {
            transform.position = spawnPoint1.position;
        }
    }
}