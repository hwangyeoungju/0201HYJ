using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using System;
using UnityEngine.XR.Interaction.Toolkit;


public class SliceObject : MonoBehaviour
{
    public Material materialSlicedSide;
    public float explosionForce;
    public float explosionRadius;
    public bool gravity, kinematic;

    // 슬라이스할 때 사용할 평면 방향
    private Vector3 sliceDirection = Vector3.up;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("MeatPiece"))
        {
            sliceDirection = transform.rotation * Vector3.right;

            SlicedHull sliceobj = Slice(other.gameObject, materialSlicedSide, sliceDirection);
            GameObject SlicedObjTop = sliceobj.CreateUpperHull(other.gameObject, materialSlicedSide);
            GameObject SlicedObjDown = sliceobj.CreateLowerHull(other.gameObject, materialSlicedSide);
            Destroy(other.gameObject);
            AddComponent(SlicedObjTop);
            AddComponent(SlicedObjDown);
        }
    }

    private SlicedHull Slice(GameObject obj, Material mat, Vector3 direction)
    {
        // 슬라이스할 때 사용할 평면 방향을 direction으로 설정
        return obj.Slice(transform.position, direction, mat);
    }

    void AddComponent(GameObject obj)
    {

        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.isKinematic = kinematic;
        rigidbody.AddExplosionForce(explosionForce, obj.transform.position, explosionRadius);
        obj.tag = "MeatPiece";

        XRGrabInteractable grabInteractable = obj.AddComponent<XRGrabInteractable>();
    }

}