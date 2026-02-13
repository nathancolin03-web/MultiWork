using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float timeOffSet;
    public Vector3 offSet;
    private Vector3 velocity;
    void Awake()
    {
        transform.position = target.position + offSet;
    }

    
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offSet, ref velocity, timeOffSet);
    }
}
