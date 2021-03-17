using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrigger : MonoBehaviour
{
    public bool isCupIn;
    private TableManager TableMNGR;
    private void Awake()
    {
        TableMNGR = FindObjectOfType<TableManager>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teacups")
        {
            //Debug.Log("Teddybear is in plaace");
            TableMNGR.increaseTeacups();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Teacups")
        {
            TableMNGR.DecreaseTeacups();
        }
    }
}
