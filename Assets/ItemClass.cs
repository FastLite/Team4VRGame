using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CountryDesc
{
     public string Country;
     public string Size;
     public int Population;
     public List<Foods> Foods;
}

[System.Serializable]
public class Foods
{
     public string foodName;
     public string foodDesc;
     public int foodAmount;
}
