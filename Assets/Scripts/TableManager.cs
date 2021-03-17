using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TableManager : MonoBehaviour
{
    public int plates;
    public int teacups;
    public TextMeshProUGUI plateText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plates == 2 && teacups == 1)
        {
            plateText.gameObject.SetActive(true);
        }
    }

    public void increaseplate()
    {
        plates += 1;
       

        if (plates == 4)
        {
            plateText.text = "four plates were placed";
        }
    }
    public void Decreaseplate()
        {
        plates -= 1;
       
    }
    public void increaseTeacups()
    {
        teacups += 1;
    }
    public void DecreaseTeacups()
    {
        teacups -= 1;
    }
}
