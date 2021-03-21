using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class TableManager : MonoBehaviour
{
    public int plates;
    public int teacups;
    public int currentRandomNumber;
    public float spacing = .5f;

    private int maxPlates;
    private int maxCups;

    public GameObject triggerPairPrefab;
    public GameObject platePrefab;
    public GameObject cupPrefab;
    
    public TextMeshProUGUI winText;
    public TextMeshProUGUI plateCountText;
    public TextMeshProUGUI cupCountText;
    public TextMeshProUGUI teddyBearCountText;

    public List<Image> plateIcons = new List<Image>();
    
    public List<Transform> triggersSpawnPonts ;
    public List<Transform> platesSpawnPonts ;
    
    public Transform parentForTriggers;

    private void Awake()
    {
        currentRandomNumber = Random.Range(0,triggersSpawnPonts.Count);
        InstantiateTriggerPair(triggersSpawnPonts[currentRandomNumber]);
        triggersSpawnPonts.RemoveAt(currentRandomNumber);
        
        int pairsTorGenerate = Random.Range(0,triggersSpawnPonts.Count) ;
        for (int i = 0; i < pairsTorGenerate; i++)
        {
            currentRandomNumber = Random.Range(0,triggersSpawnPonts.Count);   
            InstantiateTriggerPair(triggersSpawnPonts[currentRandomNumber]);
            triggersSpawnPonts.RemoveAt(currentRandomNumber);
        }

        for (int i = 0; i < pairsTorGenerate; i++)
        {
            Instantiate(platePrefab, platesSpawnPonts[0]);
            //Instantiate(cupPrefab);
            
        }
    }

    void Start()
    {
        plateCountText.text = "Plates Placed : " + plates;
        cupCountText.text = "Teacups Placed : " + teacups;
    }

    void Update()
    {
        if (plates == maxPlates && teacups == maxCups)
        {
            winText.text = "Successfully Completed the Task";
        }
    }

    public void ChangePlateCount(int number)
    {
        plates += number;
        plateCountText.text = "Plates Placed : " + plates;
       


    }
    public void ChangeTeacupsCount(int number)
    {
        teacups += number;
        cupCountText.text = "Teacups Placed : " + teacups;
    }

    public void InstantiateTriggerPair(Transform location)
    {
        Instantiate(triggerPairPrefab, new Vector3(location.position.x, location.position.y, location.position.z), location.rotation );
        maxCups++;
        maxPlates++;
    }
   
}
