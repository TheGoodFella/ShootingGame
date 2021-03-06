﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class KawaseBlur : MonoBehaviour
{
    private Material m_Material;
    private Shader m_Shader;
    static public bool enable = true;

    private void OnEnable()
    {
        if (enable)
        {
            m_Shader = Shader.Find("hidden/kawase_blur");
            if (m_Shader.isSupported == false)
            {
                enabled = false;
                Debug.LogWarning("Shader not supported");
                return;
            }
            m_Material = new Material(m_Shader);
        }
    }


    private void OnRenderImage(RenderTexture input, RenderTexture output)
    {
        if (enable)
            Graphics.Blit(input, output, m_Material);
    }
}