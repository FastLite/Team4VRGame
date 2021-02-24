using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    private TableManager TableMNGR;
    // Start is called before the first frame update
    private void Awake()
    {
        TableMNGR = FindObjectOfType<TableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plates")
        {
            //Debug.Log("Teddybear is in plaace");
            TableMNGR.increaseplate();
        }
    }

    void plateOnTrrigger()
    {

    }
}
