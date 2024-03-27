using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private Button setDeets;

    // [SerializeField] private GameObject inpIpParent;
    [SerializeField] private TextMeshProUGUI inpIp;
    [SerializeField] private TextMeshProUGUI inpPort;

    [SerializeField] private TextMeshProUGUI currentIP;

    private string GetLocalIpAddress() {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        return "sike there isn't a real ip address bozo";
    }

    private void InitializeTransport() {
        UnityTransport ut = NetworkManager.Singleton.GetComponent<UnityTransport>();
        if (ut != null) {

            string ip = System.Text.RegularExpressions.Regex.Replace(inpIp.text, "[^0-9.]", "");
            string pt = inpPort.text;
            ushort port = ushort.Parse(pt.Substring(0, pt.Length - 1));

            // string ip = GetLocalIpAddress();
            // ushort port = 7777;
            Debug.Log("IP: " + ip + "\tPort: " + port);
            ut.ConnectionData.Address = ip;
            ut.ConnectionData.Port = port;
            // ut.SetConnectionData(ip, port);
        } else {
            Debug.Log("UnityTransport getcomponent failed");
        }
    }

    private void Awake() {
        // foreach(Transform child in inpIpParent.transform) {
        //     // Debug.Log(child);
        //     // Debug.Log(child.name);
        //     if (child.name == "IPText") {
        //         inpIp = child.gameObject;
        //     }
        // }

        string _localIp = GetLocalIpAddress();
        currentIP.text = "Current IP: " + _localIp;

        hostBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });

        clientBtn.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });

        setDeets.onClick.AddListener(() => {
            InitializeTransport();
        });
    }
}
