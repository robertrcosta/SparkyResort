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
    public TextMeshProUGUI moneyTextField;
    public TextMeshProUGUI populationTextField;

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
        CalculateMaxPopulation();

        UpdateMoneyLabel();
        UpdatePopulationLabel();
    }

    public void UpdateMoneyLabel()
    {
        moneyTextField.text = string.Format("€{0}", new object[1] { money });
    }
    public void UpdatePopulationLabel()
    {
        populationTextField.text = $"{curPopulation} / {maxPopulation} (max)";
    }

    public void SpendMoney(int amount)
    {

		print($"Spending €{amount}");
        money -= amount;
    }

    void CalculateMaxPopulation()
    {
        maxPopulation = 0;

        foreach (BuildingPreset building in buildings)
            maxPopulation += building.population;
		
    }

    void CalculateNewVisitors()
    {
        int newVisitors = Random.Range(1, 20);
        int maxSpaceAvailable = maxPopulation - curPopulation;

        int newVisitorsAllowed = Mathf.Min(newVisitors, maxSpaceAvailable);

        if(newVisitorsAllowed >= newVisitors) 
        {
            curPopulation += newVisitors;
            print($"{newVisitors} guests have arrived on our resort!");
        } else {
            curPopulation += newVisitorsAllowed;
            print($"{newVisitors} guests have arrived, but we only had room for {newVisitorsAllowed} guests on our resort. Build more rooms!");
        }
    }

    public void GameLoop()
    {
        
        CalculateNewVisitors();
        money += curPopulation;
        CalculateMaxPopulation();

        UpdateMoneyLabel();
        UpdatePopulationLabel();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyLabel();
        UpdatePopulationLabel();

        InvokeRepeating("GameLoop", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
