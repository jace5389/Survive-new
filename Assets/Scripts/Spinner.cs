using UnityEngine;

public class Spinner : MonoBehaviour
{ 
    public float speed = 100f;
    public Vector3 roatationAxis = new Vector3(0, 1, 0);

    
    void Update()
    {
        // Rotate the object around the specified axis at the defined speed
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}

