using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ParallaxController : MonoBehaviour
{
    private const float minimumVelocity_X = 1.5f;

    [SerializeField] private Vector2 parallaxEffectMultiplier;
    [SerializeField] private GameObject player;
    //private Rigidbody2D playerRigidBody;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    //private float textureUniteSize_X;
    //private float textureUniteSize_Y;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        //Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //Texture2D texture = sprite.texture;
        //textureUniteSize_X = texture.width / sprite.pixelsPerUnit;
        //textureUniteSize_Y = texture.height / sprite.pixelsPerUnit;
        //playerRigidBody = player.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (this.player != null)
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

            this.transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
            lastCameraPosition = cameraTransform.position;
        }       
    }
}
