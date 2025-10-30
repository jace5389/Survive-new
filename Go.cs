using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // Move to the right every frame
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
