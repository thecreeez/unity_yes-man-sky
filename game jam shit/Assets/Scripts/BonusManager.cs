using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private float boostImpact;

    [SerializeField] private GameObject gasCollectParticlePrefab;
    [SerializeField] private GameObject coinCollectParticlePrefab;
    [SerializeField] private GameObject boosterCollectParticlePrefab;

    [SerializeField] private List<GameObject> particles;

    public void Update()
    {
        var particlesToKill = new List<GameObject>();
        foreach (var particle in particles)
        {
            if (!particle.GetComponent<ParticleSystem>().isPlaying)
                particlesToKill.Add(particle);
        }

        foreach (var particle in particlesToKill)
        {
            particles.Remove(particle);
            Destroy(particle);
        }
    }

    public void collect(GameObject bonus)
    {
        var bonusPosition = bonus.transform.position;
        switch (bonus.tag)
        {
            case "gas":
                var gasCollectParticle = Instantiate(gasCollectParticlePrefab, new Vector3(bonusPosition.x, bonusPosition.y, bonusPosition.z), Quaternion.identity);
                gasCollectParticle.GetComponent<ParticleSystem>().Play();

                particles.Add(gasCollectParticle);

                GameManager.instance.useGas();
                break;
            case "coin":
                var coinCollectParticle = Instantiate(coinCollectParticlePrefab, new Vector3(bonusPosition.x, bonusPosition.y, bonusPosition.z), Quaternion.identity);
                coinCollectParticle.GetComponent<ParticleSystem>().Play();

                particles.Add(coinCollectParticle);

                GameManager.instance.useCoin();
                break;
            case "boost":
                var boosterCollectParticle = Instantiate(boosterCollectParticlePrefab, new Vector3(bonusPosition.x, bonusPosition.y, bonusPosition.z), Quaternion.identity);
                boosterCollectParticle.GetComponent<ParticleSystem>().Play();

                GameManager.instance.setGameSpeed(GameManager.instance.getGameSpeed() + boostImpact / GameManager.instance.getGameSpeed());

                particles.Add(boosterCollectParticle);
                break;
        }

        Destroy(bonus.gameObject);
    }
}
