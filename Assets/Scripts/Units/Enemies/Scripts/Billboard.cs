using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform m_cameraTrans;

    private void Start() {
        m_cameraTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_cameraTrans.forward);
    }
}
