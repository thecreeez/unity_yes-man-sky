using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]private float distanceReached = 0f;
    [SerializeField][Range(0f,4f)]private float gameSpeed = 1f;
    [SerializeField] private float fuelConsumption = 0.1f;

    [SerializeField] private AudioSource vzhhhhhhhh;

    private float maxFuel = 400f;
    private float fuel = 400f;
    private float fuelInGas = 50f;

    private bool isPlaying = true;

    private int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

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
