using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]private float distanceReached;
    [SerializeField][Range(0f,4f)]private float gameSpeed;
    [SerializeField] private float fuelConsumption;

    [SerializeField] private AudioSource vzhhhhhhhh;

    [SerializeField] private float maxFuel = 400f;
    [SerializeField] private float fuel = 400f;
    [SerializeField] private float fuelInGas = 50f;

    [SerializeField] private bool isPlaying = true;

    [SerializeField] private int coins = 0;

    // Start is called before the first frame update
    void Start()
    {   
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        if (!PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins", 0);

        coins = PlayerPrefs.GetInt("coins");
    }

    // Update is called once per frame
    void Update()
    {
        if (vzhhhhhhhh)
        {
            if (gameSpeed > 0 && !vzhhhhhhhh.isPlaying)
                vzhhhhhhhh.Play();

            if (gameSpeed <= 0 && vzhhhhhhhh.isPlaying)
                vzhhhhhhhh.Stop();
        }

        distanceReached += 20 * gameSpeed * Time.deltaTime;
        fuel -= gameSpeed * fuelConsumption * Time.deltaTime;

        if (fuel <= 0)
            lose();
    }

    public void useGas()
    {
        fuel += fuelInGas;

        if (fuel > maxFuel)
            fuel = maxFuel;
    }

    public void useCoin()
    {
        coins++;

        PlayerPrefs.SetInt("coins", coins);
    }

    public float getDistanceReached()
    {
        return distanceReached;
    }

    public void setGameSpeed(float speed)
    {
        gameSpeed = speed;
    }

    public float getGameSpeed()
    {
        return gameSpeed;
    }

    public float getFuel()
    {
        return fuel;
    }

    public float getMaxFuel()
    {
        return maxFuel;
    } 

    public float getFuelInPercents()
    {
        return fuel / maxFuel;
    }

    public int getCoins()
    {
        return coins;
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void lose()
    {
        gameSpeed = 0f;
        isPlaying = false;
    }

    public bool getIsPlaying()
    {
        return isPlaying;
    }
}
