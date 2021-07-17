using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        // Recycle the bullet after 2 seconds.
        Invoke("Hide", 2f);    
    }

    void Hide()
    {
        // Recycle the gameObject
        this.gameObject.SetActive(false);
    }
}
