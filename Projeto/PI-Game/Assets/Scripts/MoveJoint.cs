using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoint : MonoBehaviour
{
    [SerializeField]
    private SliderJoint2D slider;
    [SerializeField]
    private JointMotor2D aux;

    void Start()
    {
        aux = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.limitState == JointLimitState2D.LowerLimit) {
            aux.motorSpeed = 1;
            slider.motor = aux;
        }
        if (slider.limitState == JointLimitState2D.UpperLimit) {
            aux.motorSpeed = -1;
            slider.motor = aux;
        }
    }
}
