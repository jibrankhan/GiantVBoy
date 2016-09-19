using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Extender : MonoBehaviour {

    public GreekGod gg;
    public float snapRange;

    protected GameObject stickObject;
    protected bool stick;
    protected ThunderCloud[] thunderClouds;
    protected CloudCollision[] rainClouds;
    protected Ruin[] ruins;
    protected float speed;
    protected Vector3 lastPosition = Vector3.zero;

    public Boy boy;
    protected Rigidbody r;
}
