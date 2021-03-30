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
    public int FilledCups;
    public int currentRandomNumber;
    public float spacing = .25f;

    private int maxPlates;
    private int maxCups;

    //Gameobjects
    public GameObject triggerPairPrefab;
    public GameObject platePrefab;
    public GameObject cupPrefab;
    
    //TextMeshPro
    public TextMeshProUGUI winText;

    //SpawnPoints
    public List<Transform> triggersSpawnPonts ;
    public List<Transform> platesSpawnPonts ;
    public Transform cupSpawnPoint ;

   
    /// UI Components
    public RectTransform platesIconSpawnPoints;
    public GameObject plateIconPrefab;
    public RectTransform cupIconSpawnPoints;
    public GameObject cupIconPrefab;




    private void Awake()
    {
       
    }

    void Start()
    {
        currentRandomNumber = Random.Range(0,triggersSpawnPonts.Count);
        InstantiateTriggerPair(triggersSpawnPonts[currentRandomNumber]);
        triggersSpawnPonts.RemoveAt(currentRandomNumber);
        
        int pairsTorGenerate = Random.Range(0,triggersSpawnPonts.Count);
        
        for (int i = 0; i < pairsTorGenerate; i++)
        {
            currentRandomNumber = Random.Range(0,triggersSpawnPonts.Count);   
            InstantiateTriggerPair(triggersSpawnPonts[currentRandomNumber]);
            triggersSpawnPonts.RemoveAt(currentRandomNumber);
        }

        for (int i = 0; i < pairsTorGenerate +1; i++)
        {
            Instantiate(platePrefab, platesSpawnPonts[0]);
            var position = cupSpawnPoint.position;
            Instantiate(cupPrefab, new Vector3(position.x, position.y, position.z + spacing * i), cupSpawnPoint.rotation);
            
            Instantiate(plateIconPrefab, platesIconSpawnPoints);
            Instantiate(cupIconPrefab, cupIconSpawnPoints);

        }

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
    }
    public void ChangeTeacupsCount(int number)
    {
        teacups += number; 
    }
    public void ChangeFillCount(int number)
    {
        FilledCups += number; 
    }

    public void InstantiateTriggerPair(Transform location)
    {
        Instantiate(triggerPairPrefab, new Vector3(location.position.x, location.position.y, location.position.z), location.rotation );
        maxCups++;
        maxPlates++;
    }
   
}
