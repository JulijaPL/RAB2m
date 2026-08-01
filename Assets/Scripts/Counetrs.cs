using TMPro;
using UnityEngine;

public class Counetrs : MonoBehaviour
{

    public TextMeshProUGUI DrinksTextCounter;
    public TextMeshProUGUI DrinksTextPCounter;
    [SerializeField] int drinksCounter = 0;
    [SerializeField] int pCounter = 0;

    public TextMeshProUGUI BadCounter;
    [SerializeField] int badCounter = 0;

    public TextMeshProUGUI GoodCounter;
    [SerializeField] int goodCounter = 0;

    public BeerSpawner spawner;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinksCounter = PlayerPrefs.GetInt("Drinks", 0);
        DrinksTextCounter.text = drinksCounter.ToString();
        DrinksTextPCounter.text = pCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddBeer()
    {
        drinksCounter++;
        pCounter++;
        DrinksTextCounter.text = drinksCounter.ToString();
        DrinksTextPCounter .text = pCounter.ToString();
       
        if (pCounter == 3)
        {
            EasyLevel();
        }else if (pCounter == 5)
        {
            NormalLevel();
        }
        else if (pCounter == 8)
        {
            HarderLevel();
        }
        else if (pCounter == 12)
        {
            HardestLevel();
        }
        PlayerPrefs.SetInt("Drinks", drinksCounter);
      
    }

    public void AddBadIngredients()
    {
        badCounter++;
        BadCounter.text = badCounter.ToString();
    }

    public void AddGoodIngredients()
    {
        goodCounter++;
        GoodCounter.text = goodCounter.ToString();
    }
    
    void EasyLevel()
    {
        spawner.spawnRate = 8f;
        spawner.spawnRange = 8f;
        spawner.fallingSpeed = 2.5f;
    }

    void NormalLevel()
    {
        spawner.spawnRate = 9f;
        spawner.spawnRange = 7f;
        spawner.fallingSpeed = 4f;
        spawner.spawnY = 8f;
    }

    void HarderLevel()
    {
        spawner.spawnRate = 8f;
        spawner.spawnRate = 8f;
        spawner.fallingSpeed = 3.5f;
        spawner.spawnY = 10f;
    }

    void HardestLevel()
    {
        spawner.spawnRate = 10f;
        spawner.spawnRange = 10f;
        spawner.fallingSpeed = 4.5f;
        spawner.spawnY = 12f;
    }
}
