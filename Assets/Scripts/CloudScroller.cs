using UnityEngine;

public class CloudScroller : MonoBehaviour
{
    public Renderer rend;
    public Vector2 scrollSpeed = new Vector2(0.02f, 0.0f);

    private Vector2 offset;

    void Awake()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();

        rend.material = new Material(rend.sharedMaterial);
    }

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;

        offset.x = Mathf.Repeat(offset.x, 1f);
        offset.y = Mathf.Repeat(offset.y, 1f);

        if (rend.material.HasProperty("_BaseMap"))
        {
            rend.material.SetTextureOffset("_BaseMap", offset);
        }
        // else if (rend.material.HasProperty("_MainTex"))
        // {
        //     rend.material.SetTextureOffset("_MainTex", offset);
        // }
    }
}
