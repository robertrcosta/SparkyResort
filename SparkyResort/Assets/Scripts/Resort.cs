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
        CalculatePopulation();
        UpdateMoney();
        UpdatePopulation();
    }

    public void UpdateMoney()
    {
        moneyTextField.text = string.Format("€{0}", new object[1] { money });
    }
    public void UpdatePopulation()
    {
        populationTextField.text = $"{curPopulation} / {maxPopulation} (max)";
    }

    public void SpendMoney(int amount)
    {

		print($"Spending €{amount}");
        money -= amount;
    }

    void CalculatePopulation()
    {
        maxPopulation = 0;

        foreach (BuildingPreset building in buildings)
            maxPopulation += building.population;
		
    }

    public void GameLoop()
    {
        curPopulation = Mathf.Min(maxPopulation, curPopulation + Random.Range(1, 20));
        money += curPopulation;
        UpdateMoney();
        CalculatePopulation();
        UpdatePopulation();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
        UpdatePopulation();
        InvokeRepeating("GameLoop", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
