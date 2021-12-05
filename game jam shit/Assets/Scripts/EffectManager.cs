using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem engine1;
    [SerializeField] private ParticleSystem engine2;

    [SerializeField] private ParticleSystem warp;

    public static EffectManager instance = null;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var speed = GameManager.instance.getGameSpeed();

        if (GameManager.instance.getIsPlaying())
        {
            var engine1main = engine1.main;
            engine1main.startLifetime = 0.72f * speed;

            var engine2main = engine2.main;
            engine2main.startLifetime = 0.72f * speed;

            var mainWarp = warp.main;
            mainWarp.simulationSpeed = speed * 1.91f;
        }
    }

    public void stopEffects()
    {
        var engine1main = engine1.main;
        engine1main.startLifetime = 0f;

        var engine2main = engine2.main;
        engine2main.startLifetime = 0f;

        var mainWarp = warp.main;
        mainWarp.simulationSpeed = 0f;
    }
}
