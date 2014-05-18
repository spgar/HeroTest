using UnityEngine;
using System.Collections;

public class BlockCarrier : MonoBehaviour
{
    public float maxRangeForPickup;
    public float dropExplosiveForce;
    public float dropExplosiveRadius;
    public LayerMask potentialPickups;
    private GameObject pickedUpObject;
    public MouseLook mouseLook;

	void Start()
	{
        pickedUpObject = null;
	}

    void PickupObject(GameObject obj)
    {
        pickedUpObject = obj;
        pickedUpObject.transform.parent = Camera.mainCamera.transform;
        pickedUpObject.rigidbody.isKinematic = true;
        pickedUpObject.rigidbody.useGravity = false;

        mouseLook.minimumY = -40.0f;
        mouseLook.maximumY = 40.0f;
    }

    void DropObject()
    {
        pickedUpObject.transform.parent = null;
        pickedUpObject.rigidbody.isKinematic = false;
        pickedUpObject.rigidbody.useGravity = true;
        pickedUpObject.rigidbody.AddExplosionForce(dropExplosiveForce, transform.position, dropExplosiveRadius);
        pickedUpObject = null;
      
        mouseLook.minimumY = -60.0f;
        mouseLook.maximumY = 60.0f;
    }
	
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedUpObject == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxRangeForPickup, potentialPickups))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
                return;
            }
        }
	}
}
