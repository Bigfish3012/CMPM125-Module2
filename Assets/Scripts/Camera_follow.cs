using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 2f;
    [SerializeField] private float orbitSpeed = 30f;

    private float angle = 0f;

    void LateUpdate()
    {
        if (!target) return;

        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Cos(rad) * distance,
            height,
            Mathf.Sin(rad) * distance
        );

        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}
