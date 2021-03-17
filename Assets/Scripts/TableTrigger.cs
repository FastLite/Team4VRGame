using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public enum TRIGGER_TYPE {Plate, Cup, Bear};
public class TableTrigger : MonoBehaviour
{
    public bool isPlateIn;
    private TableManager TableMNGR;
    public GameObject CheckMarkParticle;


    public TRIGGER_TYPE TriggerType;
     
    private void Awake()
    {
        TableMNGR = FindObjectOfType<TableManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    { 
        
        if (other.gameObject.CompareTag("Plates") && TriggerType == TRIGGER_TYPE.Plate)
        {
            TableMNGR.increaseplate();
            gameObject.GetComponent<Renderer>().enabled = false;
            Instantiate(CheckMarkParticle, gameObject.transform);
        }

        if (other.gameObject.CompareTag("Teacups") && TriggerType == TRIGGER_TYPE.Cup)
        {
            TableMNGR.increaseTeacups();
            gameObject.GetComponent<Renderer>().enabled = false;
            Instantiate(CheckMarkParticle, gameObject.transform);
            
        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Plates") && TriggerType == TRIGGER_TYPE.Plate)
        {
            TableMNGR.Decreaseplate();
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        if (other.gameObject.CompareTag("Teacups") && TriggerType == TRIGGER_TYPE.Cup)
        {
            TableMNGR.DecreaseTeacups();
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
