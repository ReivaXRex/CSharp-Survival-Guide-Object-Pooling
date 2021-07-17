using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = PoolManager.Instance.RequestBullet();
            
           // Vector3 offset = new Vector3(0, 1.5f, 0);
           // Vector3 newPos = transform.position + offset;
           // Instantiate(bulletPrefab, newPos, Quaternion.identity);
        }
    }
}
