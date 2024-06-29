using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] 
    private Transform _examineTarget;

    public void PerformExamine(Examinable examinable)
    {
        examinable.transform.position = _examineTarget.position;
        examinable.transform.parent = _examineTarget;
    }
}
