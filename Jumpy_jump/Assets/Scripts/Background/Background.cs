using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Background : MonoBehaviour
{

    [SerializeField] private Material BackgroundImage;
    [SerializeField] private float Speed;

    private void Start()
    {
        BackgroundImage = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        BackgroundImage.mainTextureOffset = new Vector2(BackgroundImage.mainTextureOffset.x+Speed*Time.deltaTime, 0);
    }

}
