using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resort : MonoBehaviour
{
    public int money;
    public int day;
    public int curPopulation;
    public int curJobs;
    public int curFood;
    public int maxPopulation;
    public int maxJobs;
    public int incomePerJob;

    public TextMeshProUGUI statsText;

    private List<BuildingPreset> buildings = new List<BuildingPreset>();

    public static Resort inst;

    void Awake()
    {
        inst = this;
    }

    public void OnPlaceBuilding(BuildingPreset building)
    {
        maxPopulation += building.population;
        buildings.Add(building);
    }

    void CalculateMoney()
    {
		print("CalculateMoney");
    }

    void CalculatePopulation()
    {
        maxPopulation = 0;

        foreach (BuildingPreset building in buildings)
            maxPopulation += building.population;
		
    }

    public void EndTurn()
    {
        day++;
        CalculateMoney();
        CalculatePopulation();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
