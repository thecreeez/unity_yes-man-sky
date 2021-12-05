using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopAHAAHAHAHAH : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    [SerializeField] private float coins;
    public Text CoinsTXT;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins", 0);
        
        CoinsTXT.text = PlayerPrefs.GetInt("coins").ToString();
            

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 2000;
        shopItems[2, 3] = 3500;
        shopItems[2, 4] = 4446;

        //Quantity
        //shopItems[3, 1] = 123;
        //shopItems[3, 2] = 123;
        //shopItems[3, 3] = 123;
        //shopItems[3, 4] = 123;



    }


    public void Buy()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("Event"));
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID] && PlayerPrefs.GetInt("isBuyShip") != 1)
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = PlayerPrefs.GetInt("coins").ToString();
            PlayerPrefs.SetInt("isBuyShip", 1);
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

        }
    }
}
