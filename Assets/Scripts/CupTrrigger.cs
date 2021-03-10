using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrrigger : MonoBehaviour
{
    public bool isCupIn;
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
