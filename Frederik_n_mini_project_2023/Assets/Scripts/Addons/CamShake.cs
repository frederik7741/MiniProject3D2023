using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Debug.Log("Shake coroutine started");

        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        Debug.Log("Shake coroutine ended");

    }
}