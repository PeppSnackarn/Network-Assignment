using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using TMPro;

public class Chat : NetworkBehaviour
{
    public static Chat instance;

    [SerializeField] private TextMeshProUGUI chat;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Canvas canvas = instance.GetComponentInParent<Canvas>();
        }
        else
        {
            Destroy(this);
        }
        chat.text = "";
    }

    [Rpc(SendTo.Server)]
    public void SubmittChatRPC(FixedString128Bytes message, float playerID)
    {
        UpdateChatRPC(message, playerID);
        chat.text = new string("Player "+playerID.ToString()+": "+message.ToString());
    }
    
    [Rpc(SendTo.Everyone)]
    private void UpdateChatRPC(FixedString128Bytes message, float playerID)
    {
        chat.text = new string("Player "+playerID.ToString()+": "+message.ToString());
    }
}
