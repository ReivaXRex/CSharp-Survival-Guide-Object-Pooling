using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletPool; 
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletContainer;
    
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Pool Manager is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _bulletPool = GenerateBullet(10); 
    }

    List<GameObject> GenerateBullet(int amountOfBullets)
    {
        for (int i = 0; i < amountOfBullets; i++) // If a bullet needs to be created...
        {
            // Create a reference to the created bullet.
            GameObject bullet = Instantiate(_bulletPrefab);
            // Assign the bullet to the bullet container in the Hierarchy.
            bullet.transform.parent = _bulletContainer.transform;
            // Disable the bullet.
            bullet.SetActive(false);
            // Add the bullet to the List.
            _bulletPool.Add(bullet);
        }

        // Return the list with the specified amount of bullets.
        return _bulletPool;
    }

    public GameObject RequestBullet()
    {
        foreach (var bullet in _bulletPool) // Loop through the bullet list
        {
            if (bullet.activeInHierarchy == false) // Check for inactive bullet
            {
                // Activate the bullet.
                bullet.SetActive(true);
                // Return the activated bullet.
                return bullet;
            }
            
        }

        // If no bullets are available (all are turned on)
        // Generate x amount of bullets and run the Request Bullet method.
        
        // Create a new bullet without overriding the current.
        GameObject newBullet = Instantiate(_bulletPrefab);
        // Assign the bullet to the bullet container in the Hierarchy.
        newBullet.transform.parent = _bulletContainer.transform;
        newBullet.SetActive(false);
        _bulletPool.Add(newBullet);

        return newBullet;
    }
}
