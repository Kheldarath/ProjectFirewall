using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = moveSpeed * Time.deltaTime; //makes the move speed independent of frame
        material.mainTextureOffset += offset; //this will keep adding the offset each frame
    } 
}
