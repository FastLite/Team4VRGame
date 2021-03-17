using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TableManager : MonoBehaviour
{
    public int plates;
    public int teacups;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI plateCountText;
    public TextMeshProUGUI cupCountText;
    public TextMeshProUGUI teddyBearCountText;

    public List<Image> plateIcons = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        plateCountText.text = "Plates Placed : " + plates.ToString();
        cupCountText.text = "Teacups Placed : " + teacups.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (plates == 4 && teacups == 1)
        {
            winText.text = "Successfully Completed the Task";
        }
    }

    public void increaseplate()
    {
        plates += 1;
        plateCountText.text = "Plates Placed : " + plates.ToString();
       


    }
    public void Decreaseplate()
    {
        plates -= 1;
        plateCountText.text = "Plates Placed : " + plates.ToString();

    }
    public void increaseTeacups()
    {
        teacups += 1;
        cupCountText.text = "Teacups Placed : " + teacups.ToString();
    }
    public void DecreaseTeacups()
    {
        teacups -= 1;
        cupCountText.text = "Teacups Placed : " + teacups.ToString();
    }
}
