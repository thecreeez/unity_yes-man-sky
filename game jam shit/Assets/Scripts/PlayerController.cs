using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private int speed;
    [SerializeField] private float lineDistance;
    [SerializeField] private AnimationController animationController;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform explosionPlace;

    [SerializeField] private BonusManager bonusManager;

    [SerializeField] private GameObject model;

    private int[] pos = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        bonusManager = GetComponent<BonusManager>();

        pos[0] = 1;
        pos[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.getIsPlaying())
            return;

        if (SwipeController.swipeRight && pos[0] < 2)
        {
            pos[0]++;
            animationController.RotateByMove(new Vector3(0f, 0f, 40f));
        }

        if (SwipeController.swipeLeft && pos[0] > 0)
        {
            pos[0]--;
            animationController.RotateByMove(new Vector3(0f, 0f, -40f));
        }

        if (SwipeController.swipeUp && pos[1] < 2)
        {
            pos[1]++;
            animationController.RotateByMove(new Vector3(-30f, 0f, 0f));
        }

        if (SwipeController.swipeDown && pos[1] > 0)
        {
            pos[1]--;
            animationController.RotateByMove(new Vector3(20f, 0f, 0f));
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        targetPosition = Vector3.right * (lineDistance * pos[0] - 1) + Vector3.up * (lineDistance * 1.2f * pos[1]);

        if (transform.position == targetPosition)
            return;

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);


    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "obstacle":
                var explosionParticle = Instantiate(explosionPrefab, new Vector3(explosionPlace.position.x,explosionPlace.position.y,explosionPlace.position.z), Quaternion.identity);
                explosionParticle.GetComponent<ParticleSystem>().Play();
                EffectManager.instance.stopEffects();
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameManager.instance.lose();
                break;
            default:
                bonusManager.collect(other.gameObject);
                break;
        };
    }
}
