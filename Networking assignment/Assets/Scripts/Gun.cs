using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public GameObject bulletPrefab;
   public Transform firePoint;
   [SerializeField] private float fireForce = 20;

   public void Fire()
   {
      SpawnBulletRPC();
      //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      //bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
   }

   [Rpc(SendTo.Server)]
   private void SpawnBulletRPC()
   {
      NetworkObject ob = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<NetworkObject>();
      ob.Spawn();
      ob.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
   }
}
