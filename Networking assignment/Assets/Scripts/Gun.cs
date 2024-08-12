using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Gun : NetworkBehaviour
{
   public GameObject bulletPrefab;
   public Transform firePoint;

   public void Fire()
   {
      if (IsLocalPlayer)
      {
         SpawnBulletRPC();
      }
   }

   [Rpc(SendTo.Server)]
   private void SpawnBulletRPC()
   {
      NetworkObject ob = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<NetworkObject>();
      ob.Spawn();
   }
}
