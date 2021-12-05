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

    private int[] pos = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

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

        if (SwipeController.swipeUp && pos[1] < 1)
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        //Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "obstacle":
                //Destroy(other.gameObject);
                GameManager.instance.lose();
                break;
            case "fuel":
                Debug.Log("�������");
                break;
            case "coin":
                Debug.Log("�������");
                break;
            case "booster":
                Debug.Log("����������");
                break;
            case "shield":
                Debug.Log("���");
                break;
        };
    }
}
