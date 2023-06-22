using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField] private Text coins;
    [SerializeField] private Text distance;
    [SerializeField] private Slider fuel;

    [SerializeField] private GameObject losePanel;
    //[SerializeField] private Text fuel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "" + GameManager.instance.getCoins();
        distance.text = "" + Mathf.Round(GameManager.instance.getDistanceReached());

        fuel.value = GameManager.instance.getFuelInPercents();

        if (!GameManager.instance.getIsPlaying())
            losePanel.SetActive(true);
        else
            losePanel.SetActive(false);
    }
}
