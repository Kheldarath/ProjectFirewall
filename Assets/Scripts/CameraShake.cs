using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration =1.0f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; //moves the camera a randomised amount in the circle
            elapsedTime += Time.deltaTime; //keeps moving the camera for this much. this updates in realtime
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }


}
