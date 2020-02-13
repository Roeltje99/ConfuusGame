using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    [Header("Cameras")]
    public Camera cameraA = null;
    public Camera cameraB = null;

    [Header("Materials")]
    public Material cameraMatA = null;
    public Material cameraMatB = null;

    private void Start()
    {
        SetUp(cameraA, cameraMatA);
        SetUp(cameraB, cameraMatB);
    }

    private void SetUp(Camera camera, Material material)
    {
        if (camera.targetTexture != null)
        {
            camera.targetTexture.Release();
        }
        camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        material.mainTexture = camera.targetTexture;
    }
}
