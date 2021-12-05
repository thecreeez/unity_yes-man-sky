using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    [SerializeField] private GameObject engine1;
    [SerializeField] private GameObject engine2;
    [SerializeField] private GameObject warpEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem particleEngine1 = engine1.GetComponent<ParticleSystem>();
        ParticleSystem particleEngine2 = engine2.GetComponent<ParticleSystem>();

        particleEngine1.startLifetime = 0.72f * GameManager.instance.getGameSpeed();
        particleEngine2.startLifetime = 0.72f * GameManager.instance.getGameSpeed();

        ParticleSystem particleWarp = warpEffect.GetComponent<ParticleSystem>();

        var particleWarpMain = particleWarp.main;
        particleWarpMain.simulationSpeed = 1.91f * GameManager.instance.getGameSpeed();
    }
}
