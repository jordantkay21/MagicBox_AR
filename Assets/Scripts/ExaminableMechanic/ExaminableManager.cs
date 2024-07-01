using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] 
    private Transform _examineTarget;

    //Cached Values
    private Examinable currentExaminable;
    private Vector3 cachedPosition;
    private Quaternion cachedRotation;
    private Vector3 cachedScale;

    public void PerformExamine(Examinable examinable)
    {
        currentExaminable = examinable;
        // cache the examainable transform data so we can reset it
        cachedPosition = currentExaminable.transform.position;
        cachedRotation = currentExaminable.transform.rotation;
        cachedScale = currentExaminable.transform.localScale;

        // move the examinable to the target position
        currentExaminable.transform.position = _examineTarget.position;
        currentExaminable.transform.parent = _examineTarget;

        // offset the scale to fit the examinable in view
        Vector3 offsetScale = cachedScale * examinable.examineScaleOffset;
        currentExaminable.transform.localScale = offsetScale;

        print("Examine has been requested");
    }

    public void PerformUnexamine()
    {
        //reset examinable's transform data back to its original state
        currentExaminable.transform.position = cachedPosition;
        currentExaminable.transform.rotation = cachedRotation;
        currentExaminable.transform.localScale = cachedScale;
        currentExaminable.transform.parent = null;

        print("Unexamine has been requested");
    }
}
