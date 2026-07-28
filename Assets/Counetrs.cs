using TMPro;
using UnityEngine;

public class Counetrs : MonoBehaviour
{

    public TextMeshProUGUI DrinksTextCounter;
    [SerializeField] int drinksCounter = 0;

    public TextMeshProUGUI BadCounter;
    [SerializeField] int badCounter = 0;

    public TextMeshProUGUI GoodCounter;
    [SerializeField] int goodCounter = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddBeer()
    {
        drinksCounter++;
       DrinksTextCounter.text = drinksCounter.ToString();
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
    // we we we 
}
