using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;
    private Vector3 startPos;

    void Start()
    {
        // store the starting position
        startPos = transform.position;
    }

    void Update()
    {
        // move the object back and forth along the x-axis
        float x = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = startPos + Vector3.right * x;
    }
}
