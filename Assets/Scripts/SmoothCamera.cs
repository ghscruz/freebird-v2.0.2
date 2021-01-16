using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target = null;
    public Transform bird = null;
    [Range(0f,1f)]
    public float smoothTime;

    void Update()
    {
        transform.position = Vector3.Lerp (transform.position, target.position, Time.deltaTime * smoothTime);
        Vector3 direction = (bird.position - transform.position).normalized;
        transform.forward = direction;
    }
}


