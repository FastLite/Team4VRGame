using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyJunkArea : MonoBehaviour
{
    private TableManager tableManager;
    private void Awake()
    {
        tableManager = FindObjectOfType<TableManager>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plates") || other.gameObject.CompareTag("Teacups"))
        {
            tableManager.junkCollection();
            other.gameObject.SetActive(false);
        }
    }
}
