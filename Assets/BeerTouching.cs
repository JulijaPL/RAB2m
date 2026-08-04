
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BeerTouching : MonoBehaviour
{
    [SerializeField] GameObject beerImagesParents;
    [SerializeField] GameObject mojitoImagesParents;
    public TextMeshProUGUI drinkText;

    [SerializeField] Sprite[] beerSprites;
    [SerializeField] Sprite[] mojitoSprites;

    [SerializeField] Image[] beerImages;
    [SerializeField] Image[] mojitoImages;

    Image[] currentImages;
    Sprite[] currentSprites;

    private int currentImagesIndex = 0;
    private int currentSpriteIndex = 0;
    private SpriteRenderer sr;
    [SerializeField] Counetrs counter;
    public Transform SpriteTransform;

    public IngredientType currentTarget;
    void Start()
    {
        sr = GetComponentInParent<SpriteRenderer>();
       
         
        
        UpdateSprites();
        UpdateImageSet();
        UpdateDrinkText();

        if (currentTarget == IngredientType.Beer)
        {
            ShowBeer();
        }
        else if (currentTarget == IngredientType.Mojito)
        {
            ShowMojito();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();

        if (ingredient == null) return;

        if(ingredient.type == currentTarget)
        {
            ChangeSprite();
            Destroy(other.gameObject);
        }
        else
        {
            counter.AddBadIngredients();
            Destroy(other.gameObject);
        }

       /* if(other.CompareTag("Beer"))
        {
            

            ChangeSprite();
            Destroy(other.gameObject);
        }else if(other != null)
        {
            counter.AddBadIngredients();
            Destroy(other.gameObject );
        }*/
    }

    void ChangeSprite()
    {
        currentSpriteIndex++;
        counter.AddGoodIngredients();

        UpdateImages();

        if (currentSpriteIndex >= currentSprites.Length)
        {
            counter.AddBeer();
            currentSpriteIndex = 0;

            SwitchTargetRandom();
            
            UpdateSprites();
            UpdateDrinkText(); 
           return;
        }     

        sr.sprite = currentSprites[currentSpriteIndex];
    }

   /* void SwitchTarget()
    {
        if (currentTarget == IngredientType.Beer)
        {
            currentTarget = IngredientType.Mojito;
        }
        else
        {
            currentTarget = IngredientType.Beer;
        }
    }*/

    void SwitchTargetRandom()
    {
        IngredientType newTarget;

        do
        {
            newTarget = (IngredientType)Random.Range(0, 2);
        }
        while (newTarget == currentTarget);

        currentTarget = newTarget;

        if (currentTarget == IngredientType.Beer)
        {
            ShowBeer();
        }else if(currentTarget == IngredientType.Mojito)
        {
            ShowMojito();
        }
       

        UpdateSprites();
        UpdateImageSet();
        UpdateDrinkText();
       
    }
    void UpdateSprites()
    {
        switch (currentTarget)
        {
        case IngredientType.Beer:
               currentSprites = beerSprites;
                break;
        case IngredientType.Mojito:
                currentSprites = mojitoSprites;
                break;
        }
        currentSpriteIndex = 0;
        sr.sprite = currentSprites[currentSpriteIndex];

    }
    void UpdateDrinkText()
    {
        switch(currentTarget)
        {
            case IngredientType.Beer:
                drinkText.text = "- BEER -";
                break;

            case IngredientType.Mojito:
                drinkText.text = "- Mojito -";
                break;
        }
    }

    void ResetImages()
    {
        foreach(var img in currentImages)
        {
            img.color = Color.gray;
        }
        currentImagesIndex = 0;
    }

    void UpdateImageSet()
    {
        switch (currentTarget)
        {
        case IngredientType.Beer:
        currentImages = beerImages;
                SpriteTransform.localPosition = new Vector3(0, -1.61f , 0);
                break;

            case IngredientType.Mojito:
         currentImages = mojitoImages;
                SpriteTransform.localPosition = new Vector3(0, -1.85f, 0);    
                break;
        }
        ResetImages();
        
    }

   void UpdateImages()
    {
        if (currentImagesIndex < currentImages.Length)
        {
            currentImages[currentImagesIndex].color = Color.white;
            currentImagesIndex++;
        }
    }

    void ShowBeer()
    {
        beerImagesParents.SetActive(true);
        mojitoImagesParents.SetActive(false);

    }
   
    void ShowMojito()
    {
        beerImagesParents.SetActive(false);
        mojitoImagesParents.SetActive(true);
    }
}






