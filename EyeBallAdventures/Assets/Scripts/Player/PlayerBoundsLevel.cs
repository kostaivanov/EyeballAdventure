using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerBoundsLevel : MonoBehaviour
{
    [SerializeField] private Vector2 minPlayerPosition;
    [SerializeField] private Vector2 maxPlayerPosition;
    private Renderer objRenderer;
    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPlayerPosition.x, maxPlayerPosition.x),
            Mathf.Clamp(transform.position.y, minPlayerPosition.y, maxPlayerPosition.y), transform.position.z);
    }

}
