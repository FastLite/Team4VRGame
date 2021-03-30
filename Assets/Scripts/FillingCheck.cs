using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;

public class FillingCheck : MonoBehaviour
{
    public LiquidContainer container;
    public bool isFilled = false;
    

    private TableManager tableManager;
    private void Awake()
    {
        tableManager = FindObjectOfType<TableManager>();
    }
    void Start()
    {
        container = gameObject.GetComponent<LiquidContainer>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isFilled)
        {
            if (container.fillAmountPercent > .7f)
            {
                isFilled = true;
                tableManager.ChangeFillCount(1);
            }
        }
        
    }
}
