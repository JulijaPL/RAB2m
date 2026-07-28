
using UnityEngine;

public class Open_Close_Panel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //TogglePanel();
            panel.SetActive(!panel.activeSelf);
        }
        

    }

   
    void TogglePanel()
    {
        if(gameObject.activeSelf) 
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }
}
