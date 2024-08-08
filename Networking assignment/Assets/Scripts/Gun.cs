using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public GameObject bulletPrefab;
   public Transform firePoint;
   [SerializeField] private float fireForce = 20;

   public void Fire()
   {
      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
   }
}
