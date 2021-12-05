using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private float durationToRotate = 0.5f;
    [SerializeField] private float durationToStabilize = 0.5f;
    [SerializeField] private AnimationCurve rotateCurve;
    [SerializeField] private AnimationCurve stabilizationCurve;

    private Quaternion defaultRotation;
    private Coroutine _rotateCoroutine;

    public void Start()
    {
        defaultRotation = transform.localRotation;
    }
    public void RotateByMove(Vector3 dir)
    {
        var rotation = Quaternion.Euler(dir);

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);
        _rotateCoroutine = StartCoroutine(RotateByMoveCoroutine(durationToRotate, durationToStabilize, rotation));
    }

    private IEnumerator RotateByMoveCoroutine(float durationToRotate, float durationToStabilize, Quaternion rotation)
    {
        var startRotation = transform.localRotation;
        var finishRotation = startRotation * rotation;

        var time = 0f;
        while (time < durationToRotate)
        {
            time += Time.deltaTime;

            transform.localRotation = Quaternion.LerpUnclamped(
                    startRotation,
                    finishRotation,
                    rotateCurve.Evaluate(time / durationToRotate));

            yield return null;
        }

        transform.localRotation = finishRotation;

        time = 0;
        while (time < durationToRotate)
        {
            time += Time.deltaTime;

            transform.localRotation = Quaternion.LerpUnclamped(
                    finishRotation,
                    defaultRotation,
                    stabilizationCurve.Evaluate(time / durationToStabilize));

            yield return null;
        }

        transform.localRotation = defaultRotation;
    }
}
