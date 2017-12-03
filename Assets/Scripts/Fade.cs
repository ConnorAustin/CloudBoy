using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool fade;
    public bool shrink;

    public float shrinkSpeed;
    public float fadeSpeed;

    SpriteRenderer sr;

    float alpha;
    Vector3 scale;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        scale = transform.localScale;
        alpha = sr.color.a;
    }

    void Update()
    {
        if (fade)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
            alpha = Mathf.Max(0, alpha - Time.deltaTime * fadeSpeed);
        }
        if (shrink)
        {
            scale.x = Mathf.Max(0, scale.x - Time.deltaTime * shrinkSpeed);
            scale.y = Mathf.Max(0, scale.y - Time.deltaTime * shrinkSpeed);
            scale.z = Mathf.Max(0, scale.z - Time.deltaTime * shrinkSpeed);
            transform.localScale = scale;
        }
    }
}
