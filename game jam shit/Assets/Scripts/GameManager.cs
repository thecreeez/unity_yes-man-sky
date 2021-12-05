using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]private float distanceReached = 0f;
    [SerializeField][Range(0f,1f)]private float gameSpeed = 1f;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        distanceReached += 20 * gameSpeed * Time.deltaTime;
    }

    public float getDistanceReached()
    {
        return distanceReached;
    }

    public float getGameSpeed()
    {
        return gameSpeed;
    }

    public void win()
    {
        isPlaying = false;
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
