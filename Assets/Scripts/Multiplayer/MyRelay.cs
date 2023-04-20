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
    public TextMeshProUGUI inputText;
    public Button hostButton;
    public Button clientButton;
    private string joinCode;
    private int numPlayersJoined = 0;
   
    

    private void Start()
    {
        hostButton.onClick.AddListener(OnHostButtonClick);
        clientButton.onClick.AddListener(OnClientButtonClick);
        InitializeRelay();
    }

    private async void InitializeRelay()
    {
        await UnityServices.InitializeAsync();
        Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

 private async void CreateRelay()
{
    try
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(2);
        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
        Debug.Log(joinCode);
        outputText.text = "join code :" + joinCode;

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetHostRelayData(
            allocation.RelayServer.IpV4,
            (ushort)allocation.RelayServer.Port,
            allocation.AllocationIdBytes,
            allocation.Key,
            allocation.ConnectionData
        );

        NetworkManager.Singleton.StartHost();

        outputText.text = "Join code: " + joinCode;

 
        Invoke("HideOutputText", 10f);
    }
    catch (RelayServiceException e)
    {
        Debug.Log(e);
    }
}

private void HideOutputTextHost()
{
    outputText.text = "";
}



    public async void JoinRelayWithCode(string joinCode)
{
    try
    {
        Debug.Log("Joining Relay with " + joinCode);
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode.Substring(0, 6));
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

       
        Invoke("HideOutputText", 5f);
    }
    catch (RelayServiceException e)
    {
        Debug.Log(e);
    }
}

private void HideOutputText()
{
    outputText.text = "";
}

private void HideOutputTextJoin()
{
    outputText.text = "";
}


    private void OnHostButtonClick()
    {
        CreateRelay();
    }

    private void OnClientButtonClick()
    {

        JoinRelayWithCode(inputText.text);
    }


}
