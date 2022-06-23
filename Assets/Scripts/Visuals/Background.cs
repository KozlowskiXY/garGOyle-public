using UnityEngine;

public class Background : MonoBehaviour
{

    [Range(-1f, 1f)]
    public float scrollSpeed = 0.25f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;    
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex",new Vector2(0,offset));
    }
}
