using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReadWrite : MonoBehaviour
{
   [SerializeField]
   CountryDesc loadedInventory = new CountryDesc();
   [SerializeField]
   CountryDesc myInventory = new CountryDesc();

   public void WriteAllDataToJson()
   {
      Debug.Log("Saving data to json");
      string dataString = JsonUtility.ToJson(myInventory);
      
      File.WriteAllText(Application.streamingAssetsPath + "/isavedthis.json",dataString);
      Debug.Log("<color=red>Data: </color>" + dataString);

   }

   public void ReadAllJsonData()
   {
      print("Reading data");
      string dataString = File.ReadAllText(Application.streamingAssetsPath + "/BestJson.json");
      loadedInventory = JsonUtility.FromJson<CountryDesc>(dataString);
   }
   
   
}
