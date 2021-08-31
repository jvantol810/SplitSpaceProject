using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Shader dissolveShader;
    private Shader originalShader;
    private Material objMaterial;
    private bool isDissolving { get; set; }
    float fade = 1f;

    private void Awake()
    {
        isDissolving = false;
    }
    public void dissolveObject(GameObject obj)
    {
        isDissolving = true;
        objMaterial = obj.GetComponent<SpriteRenderer>().material;
        originalShader = objMaterial.shader;
        objMaterial.shader = dissolveShader;
    }

    public void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                objMaterial.shader = originalShader;
                isDissolving = false;
            }

            objMaterial.SetFloat("_Fade", fade);
        }
    }
}
