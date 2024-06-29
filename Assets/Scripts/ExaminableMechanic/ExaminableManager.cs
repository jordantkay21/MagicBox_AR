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

    public void PerformExamine(Examinable examinable)
    {
        currentExaminable = examinable;

        cachedPosition = currentExaminable.transform.position;
        cachedRotation = currentExaminable.transform.rotation;

        currentExaminable.transform.position = _examineTarget.position;
        currentExaminable.transform.parent = _examineTarget;

        print("Examine has been requested");
    }

    public void PerformUnexamine()
    {
        currentExaminable.transform.position = cachedPosition;
        currentExaminable.transform.rotation = cachedRotation;
        currentExaminable.transform.parent = null;

        print("Unexamine has been requested");
    }
}
