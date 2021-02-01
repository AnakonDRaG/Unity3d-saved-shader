using System;
using System.Collections;
using Scripts.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Helper
{
    public class CameraShake : SingletonBehaviour<CameraShake>
    {
        [SerializeField]private float duration = 0.15f;
        [SerializeField]private float magnitude = 0.05f;
        

        public IEnumerator ShakeCamera()
        {
            Vector3 originalPosition = transform.localPosition;
            float elapsed = 0.0f;

            while(elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPosition;
        }
    }
}