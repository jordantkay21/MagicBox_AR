using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField]
    private ExaminableManager _examinableManager;

    public float examineScaleOffset = 1f;
    public Transform originalParent;

    private void Start()
    {
        _examinableManager = FindAnyObjectByType<ExaminableManager>();
    }

    public void RequestExamine()
    {
        _examinableManager.PerformExamine(this);

        print("Examine has been requested");
    }

    public void RequestUnexamine()
    {
        _examinableManager.PerformUnexamine();

        print("Unexamine has been requested");
    }
}
