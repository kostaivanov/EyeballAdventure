using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithSpikeController : MonoBehaviour
{
    internal float pushForce => 30f;

    //[SerializeField] private GameObject boxEffect;
    [SerializeField] private AudioSource breakBox;
    [SerializeField] private GameObject pointsEffect;
    private GameObject clone_BoxPoint;
    private Animator boxAnimator;
    [SerializeField] private GameObject spike;
    private SpikeController spikeController;

    private void Start()
    {
        PermanentFunctions.instance.destroyedBoxesTemp = 0;
        spikeController = spike.GetComponent<SpikeController>();
        spikeController.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            breakBox.Play();
            clone_BoxPoint = Instantiate(pointsEffect, this.transform.position, Quaternion.identity);
            PushVertically(otherObject.transform);

            boxAnimator = GetComponent<Animator>();
            boxAnimator.SetTrigger("CrushTheBox");
            //boxNontrigger = GetComponent<BoxCollider2D>();
            //boxTrigger = GetComponent<EdgeCollider2D>();
            spikeController.enabled = true;

            //boxTrigger.enabled = false;
            //boxRenderer.enabled = false;

            //clone = Instantiate(boxEffect, this.transform.position, Quaternion.identity);


            //boxNontrigger.enabled = false;
            Destroy(this.gameObject, 0.3f);
            Destroy(clone_BoxPoint, 1.2f);
            //Destroy(clone, 0.5f);
            PermanentFunctions.instance.destroyedBoxesTemp++;
        }
    }


    private void PushVertically(Transform otherObject)
    {
        Vector3 pushDirection = Vector3.zero;

        if (this.transform.position.x < otherObject.transform.position.x)
        {
            pushDirection = Quaternion.AngleAxis(80f, Vector3.forward) * Vector3.right;
        }
        else if (this.transform.position.x > otherObject.transform.position.x)
        {
            pushDirection = Quaternion.AngleAxis(80f, Vector3.back) * Vector3.left;
        }

        pushDirection *= pushForce;
        Rigidbody2D pushRigidBody = otherObject.gameObject.GetComponent<Rigidbody2D>();
        pushRigidBody.velocity = Vector2.zero;
        pushRigidBody.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
