using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] 
    private Transform _examineTarget;
    [SerializeField]
    private float rotateSpeed = 1;

    private bool isExamining = false;

    //Cached Values
    private Examinable currentExaminable;
    private Vector3 cachedPosition;
    private Quaternion cachedRotation;
    private Vector3 cachedScale;

    private void Update()
    {
        if (isExamining == true)
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                    currentExaminable.transform.Rotate(touch.deltaPosition.x * -rotateSpeed, touch.deltaPosition.y * -rotateSpeed, 0);
            }
    }

    public void PerformExamine(Examinable examinable)
    {
        currentExaminable = examinable;
        currentExaminable.transform.parent = _examineTarget;
        isExamining = true;

        // cache the examainable transform data so we can reset it
        cachedPosition = currentExaminable.transform.position;
        cachedRotation = currentExaminable.transform.rotation;
        cachedScale = currentExaminable.transform.localScale;

        // move the examinable to the target position
        currentExaminable.transform.position = _examineTarget.position;

        // offset the scale to fit the examinable in view
        Vector3 offsetScale = cachedScale * examinable.examineScaleOffset;
        currentExaminable.transform.localScale = offsetScale;

        print("Examine has been requested: cachedScale = " + cachedScale + " | offsetScale = " + offsetScale + " | parent = " + currentExaminable.transform.parent);
    }

    public void PerformUnexamine()
    {
        isExamining = false;

        //reset examinable's transform data back to its original state
        currentExaminable.transform.position = cachedPosition;
        currentExaminable.transform.rotation = cachedRotation;
        currentExaminable.transform.localScale = cachedScale;
        currentExaminable.transform.parent = currentExaminable.originalParent;

        print("Unexamine has been requested: cachedScale = " + cachedScale + " | Examinable's Scale = " + currentExaminable.transform.localScale + " | parent = " + currentExaminable.transform.parent);
    }
}
