using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TableManager : MonoBehaviour
{
    public int plates;
    public Text plateText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void increaseplate()
    {
        plates += 1;

        if (plates == 4)
        {
            plateText.text = "four plates were placed";
        }
    }
}
