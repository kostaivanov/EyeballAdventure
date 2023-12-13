using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBuildings_1 : MonoBehaviour
{
    private const float minimumVelocity_X = 2f;
    //private const float minimumVelocity_Y = 1.5f;

    [SerializeField] private SpriteRenderer backGround_1;
    [SerializeField] private SpriteRenderer backGround_2;
    [SerializeField] private GameObject player;
    private Rigidbody2D playerRigidBody;
    private float size;

    [SerializeField] private float choke;
    private Vector3 bg1TargetPosition = new Vector3();
    private Vector3 bg2TargetPosition = new Vector3();

    private void Start()
    {
        size = backGround_1.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        playerRigidBody = player.GetComponent <Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player != null && Mathf.Abs(this.playerRigidBody.velocity.x) > minimumVelocity_X)
        {
            if (this.transform.position.x >= this.backGround_2.transform.position.x)
            {
                this.backGround_1.transform.position = SetPosition(bg1TargetPosition, backGround_2.transform.position.x + size, backGround_1.transform.position.y, backGround_1.transform.position.z);
                SwitchBackGrounds();
            }

            if (this.transform.position.x < backGround_1.transform.position.x)
            {
                backGround_2.transform.position = SetPosition(bg2TargetPosition, backGround_1.transform.position.x - size, backGround_2.transform.position.y, backGround_2.transform.position.z);
                SwitchBackGrounds();
            }
        }     
    }

    private void SwitchBackGrounds()
    {
        SpriteRenderer temp = backGround_1;
        backGround_1 = backGround_2;
        backGround_2 = temp;
    }

    private Vector3 SetPosition(Vector3 position, float x, float y, float z)
    {
        position.x = x;
        position.y = y;
        position.z = z;
        return position;
    }
}
