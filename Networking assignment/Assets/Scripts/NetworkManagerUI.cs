using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
   private NetworkManager _networkManager;

   private void Start()
   {
      _networkManager = GetComponent<NetworkManager>();
   }

   public void StartHost()
   {
      _networkManager.StartHost();
   }

   public void JoinHost()
   {
      _networkManager.StartClient();
   }

   public void Quit()
   {
      Application.Quit();
   }
}
