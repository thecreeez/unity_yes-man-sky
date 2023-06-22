using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _object; //An object camera will follow
    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.getIsPlaying())
            return;

        if (_object.transform.position + _distanceFromObject == transform.position)
            return;

        transform.position = Vector3.Lerp(transform.position, _object.transform.position + _distanceFromObject, speed);
    }
}
