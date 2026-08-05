using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public Image medal20;
    public Image medal0;
    public Image meda100;


   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drinksCounter = PlayerPrefs.GetInt("Drinks", 0);
        DrinksTextCounter.text = drinksCounter.ToString();
        DrinksTextPCounter.text = pCounter.ToString();

        SetMedal(medal20, "Medal20");
        SetMedal(medal0, "Medal0");
        SetMedal(meda100, "Medal100");
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

        CheckMedals();
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
        spawner.spawnRate = 1.5f;
        spawner.spawnRange = 8f;
        spawner.fallingSpeed = 2.5f;
    }

    void NormalLevel()
    {
        spawner.spawnRate = 1f;
        spawner.spawnRange = 8f;
        spawner.fallingSpeed = 3f;
        spawner.spawnY = 5f;
    }

    void HarderLevel()
    {
        spawner.spawnRate = 0.9f;
        spawner.spawnRate = 8f;
        spawner.fallingSpeed = 3.5f;
        spawner.spawnY = 5f;
    }

    void HardestLevel()
    {
        spawner.spawnRate = 0.8f;
        spawner.spawnRange = 8f;
        spawner.fallingSpeed = 4.5f;
        spawner.spawnY = 5f;
    }

    void SetMedal(Image medal, string key)
    {
        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            medal.color = Color.white;

        }else
        {
            medal.color = Color.black;
        }
    }

    void CheckMedals()
    {
        if(drinksCounter >=20 && PlayerPrefs.GetInt("Medal20",0)==0)
        {
            UnlockMedal(medal20, "Medal20");
        }
        if (badCounter == 0 && drinksCounter >= 20 && PlayerPrefs.GetInt("Medal", 0) == 0)
        {
            UnlockMedal(medal0, "Medal0");
        }
        if(goodCounter >=100 && PlayerPrefs.GetInt("Medal100", 0)== 0)
        {
            UnlockMedal(meda100, "Medal100");
        }
    }

    void UnlockMedal(Image medal, string key)

    {
        medal.color = Color.white;
        PlayerPrefs.SetInt(key, 1);
    }
}
