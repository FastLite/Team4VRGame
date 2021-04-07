using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum OBJECTIVE_TYPE {Place, Clean};

public class TableManager : MonoBehaviour
{
    //Variables
    public int plates;
    public int teacups;
    public int filledCups;
    public int currentRandomNumber;
    public int removedJunk;
    public int plateScore;
    public int cupScore;
    public float spacing = .25f;
    public int totalScore;

    
    private int maxPlates;
    private int cupsToFill;
    private int maxCups;
    public int generatedJunk;


    private float gamescale;
    public GameObject player;



    public OBJECTIVE_TYPE objectiveType;


    //Gameobjects
    public GameObject triggerPairPrefab;
    public GameObject platePrefab;
    public GameObject cupPrefab;
    public GameObject kettlePrefab;
    public GameObject PlaceGameCanvas;
    public GameObject JunkCollectingCanvas;
    
    //TextMeshPro
    public TextMeshProUGUI winText;
    public TextMeshProUGUI TotalScoreText;
    public TextMeshProUGUI removedJunkText;
    public TextMeshProUGUI totalJunkText;

    //SpawnPoints
    public List<Transform> triggersSpawnPonts ;
    public List<Transform> platesSpawnPonts ;
    public Transform cupSpawnPoint ;
    public Transform kettleSpawnPoint ;
    public Collider junkSpawnArea;


   
    /// UI Components
    public RectTransform platesIconSpawnPoints;
    public GameObject plateIconPrefab;
    public RectTransform cupIconSpawnPoints;
    public GameObject cupIconPrefab;
    





    private void Awake()
    {
        int oneOrTwo = Random.Range(0, 2);
        if (oneOrTwo == 0)
        {
            objectiveType = OBJECTIVE_TYPE.Place;
            PlaceGameCanvas.SetActive(true);
            TotalScore(0);

        }
        else
        {
            objectiveType = OBJECTIVE_TYPE.Clean;
            JunkCollectingCanvas.SetActive(true);
            totalJunkText.text = "Total Junk: " + generatedJunk;
            removedJunkText.text = "Removed Junk: " + removedJunk;
        }
    }

    void Start()
    {
    //    gamescale = PlayerPrefs.GetFloat("Hight");
    //player.transform.localPosition = new Vector3(0.9785619f, gamescale, -8.244994f);

        if (objectiveType == OBJECTIVE_TYPE.Place)
        {
            currentRandomNumber = Random.Range(0,triggersSpawnPonts.Count);
            InstantiateTriggerPair(triggersSpawnPonts[currentRandomNumber]);
            triggersSpawnPonts.RemoveAt(currentRandomNumber);
            Instantiate(kettlePrefab, kettleSpawnPoint);
        
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
                Instantiate(cupPrefab, new Vector3(position.x + spacing * i, position.y, position.z ), cupSpawnPoint.rotation);
            
                Instantiate(plateIconPrefab, platesIconSpawnPoints);
                Instantiate(cupIconPrefab, cupIconSpawnPoints);

            } 
        }
        else
        {
            for (int i = 0; i < Random.Range(10,21); i++)
            {
                Vector3 rndPoint3D = RandomPointInBounds(junkSpawnArea.bounds, 1f);
                
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360)));

                Instantiate(platePrefab,rndPoint3D,rot );
                rndPoint3D =  RandomPointInBounds(junkSpawnArea.bounds, 1f);
                    rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360)));
                
                Instantiate(cupPrefab,rndPoint3D,rot);

                generatedJunk += 2;
            }  
        }
        

    }

    void Update()
    {
        if (plates == maxPlates && teacups == maxCups && cupsToFill == filledCups && objectiveType == OBJECTIVE_TYPE.Place) 
        {
            winText.text = "Successfully Completed the Task";
        }
        else if (objectiveType == OBJECTIVE_TYPE.Clean && removedJunk == generatedJunk/2)
        {
            winText.text = "Successfully Completed the Task";
        }
        
    }
    
    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale));
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
        filledCups += number; 
    }

    public void TotalScore(int randomScore)
    {
        randomScore += totalScore;
        TotalScoreText.text = "Score: " + randomScore;
    }


    public void junkCollection()
    {
        removedJunk += 1;

        totalJunkText.text = "Total Junk: " + generatedJunk;
        removedJunkText.text = "Removed Junk: " + removedJunk;

    }

    public void InstantiateTriggerPair(Transform location)
    {
        Instantiate(triggerPairPrefab, new Vector3(location.position.x, location.position.y, location.position.z), location.rotation );
        maxCups++;
        maxPlates++;
    }

    
   
}
