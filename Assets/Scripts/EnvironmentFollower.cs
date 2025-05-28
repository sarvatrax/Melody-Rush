using UnityEngine;

public class EnvironmentFollower : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 2f;

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.z = player.position.z + offset.z;  
        transform.position = newPos;
    }
}
