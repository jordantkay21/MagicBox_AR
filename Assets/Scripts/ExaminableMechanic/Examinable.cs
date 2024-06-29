using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    [SerializeField]
    private ExaminableManager _examinableManager;

    private void Start()
    {
        _examinableManager = FindAnyObjectByType<ExaminableManager>();
    }

    public void RequestExamine()
    {
        _examinableManager.PerformExamine(this);
    }
}
