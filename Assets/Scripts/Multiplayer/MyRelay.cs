using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Services.Core;
using Unity.Services.Authentication;
using UnityEngine.Networking;
using Unity.Networking.Transport;
using Unity.Netcode.Transports.UTP;
using TMPro;

public class MyRelay : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public Button hostButton;
    public Button clientButton;

    private void Start()
    {
        hostButton.onClick.AddListener(OnHostButtonClick);
        clientButton.onClick.AddListener(OnClientButtonClick);
    }

    private async void InitializeRelay()
    {
        await UnityServices.InitializeAsync();
        Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        CreateRelay();
    }

    private async void CreateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(2);
            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log(joinCode);

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetHostRelayData(
                allocation.RelayServer.IpV4,
                (ushort)allocation.RelayServer.Port,
                allocation.AllocationIdBytes,
                allocation.Key,
                allocation.ConnectionData
            );

            NetworkManager.Singleton.StartHost();
            //outputText.text = "Join code: " + joinCode;
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    private async void JoinRelayWithCode(string joinCode)
    {
        try
        {
            Debug.Log("Joining Relay with " + joinCode);
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
           outputText.text = "Join code: " + joinCode;


            NetworkManager.Singleton.GetComponent<UnityTransport>().SetClientRelayData(
                joinAllocation.RelayServer.IpV4,
                (ushort)joinAllocation.RelayServer.Port,
                joinAllocation.AllocationIdBytes,
                joinAllocation.Key,
                joinAllocation.ConnectionData,
                joinAllocation.HostConnectionData
            );
            NetworkManager.Singleton.StartClient();

             outputText.text = "Joining relay with join code: " + joinCode;
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    private void OnHostButtonClick()
    {
        InitializeRelay();
    }

    private void OnClientButtonClick()
    {

        JoinRelayWithCode("joinCode");
    }
}
