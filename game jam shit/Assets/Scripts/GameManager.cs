using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]private float distanceReached = 0f;
    [SerializeField][Range(0f,1f)]private float gameSpeed = 1f;

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
}
