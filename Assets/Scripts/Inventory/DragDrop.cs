using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerClickHandler
{
    public GameObject prefab; // Reference to the 3D object prefab
    public float distanceFromPlayer = 2.0f; // Distance from player when 3D object is instantiated

    public void OnPointerClick(PointerEventData eventData)
    {
        // Instantiate the 3D object in front of the player
        Vector3 playerPosition = Camera.main.transform.position;
        Vector3 playerForward = Camera.main.transform.forward;
        Vector3 spawnPosition = playerPosition + playerForward * distanceFromPlayer;

        GameObject go = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // Enable the collider of the 3D object
        Collider collider = go.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
        }
    }
}


