using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = Vector3.up;

    RectTransform textTrasform;

    public void Awake()
    {
        textTrasform = GetComponent<RectTransform>();
    }

    private void Uptade()
    {
        textTrasform.position += moveSpeed * Time.deltaTime;
    }
}
