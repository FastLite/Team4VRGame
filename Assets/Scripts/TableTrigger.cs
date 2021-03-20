using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;



public enum TRIGGER_TYPE {Plate, Cup, Bear};

public class TableTrigger : MonoBehaviour
{
    public bool objectInside;
    private TableManager tableManager;
    public GameObject checkMarkParticle;


    public TRIGGER_TYPE TriggerType;

    private void Awake()
    {
        tableManager = FindObjectOfType<TableManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectInside)
        {
            if (other.gameObject.CompareTag("Plates") && TriggerType == TRIGGER_TYPE.Plate &&
                !other.GetComponent<Rigidbody>().isKinematic)
            {
                tableManager.increaseplate();
                gameObject.GetComponent<Renderer>().enabled = false;
                Instantiate(checkMarkParticle, gameObject.transform);
                Destroy(other.gameObject.GetComponent<Throwable>());
                other.transform.position = gameObject.transform.position;

            }

            if (other.gameObject.CompareTag("Teacups") && TriggerType == TRIGGER_TYPE.Cup)
            {
                tableManager.increaseTeacups();
                gameObject.GetComponent<Renderer>().enabled = false;
                Instantiate(checkMarkParticle, gameObject.transform);
                Destroy(other.gameObject.GetComponent<Throwable>());
                other.GetComponent<Interactable>().enabled = false;
            }
        }
    }


}