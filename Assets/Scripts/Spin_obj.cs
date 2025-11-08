using UnityEngine;

public class Spin_obj : MonoBehaviour
{
    [SerializeField] private float speed = 90f;

    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
