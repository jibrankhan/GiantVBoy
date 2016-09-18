using UnityEngine;
using System.Collections;
using Leap.Unity;

public class GreekGod : MonoBehaviour {

    Vector3 originalPos;

    public float shakeFactor, shakeDecreaseFactor, shakeDuration;
    private bool shaking = false;
    public Boy boy;
    public LeapRTS leap;
    public GameObject PinchExtenderLeft;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(shaking)
        {
            InitiateShake();
        }

        transform.position = new Vector3(boy.transform.position.x + 7, boy.transform.position.y + 10, boy.transform.position.z);
	}

    public void StartShake()
    {
        shaking = true;
    }

    void InitiateShake()
    {
        shakeDuration = 3f;
        ShakeCamera();
    }

    void ShakeCamera()
    {
        originalPos = transform.localPosition;

        if(shakeDuration > 0)
        {
            gameObject.transform.localPosition = originalPos + Random.insideUnitSphere * shakeFactor;
            shakeDuration -= Time.deltaTime * shakeDecreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            gameObject.transform.localPosition = originalPos;
            shaking = false;
        }
    }

    public bool IsPinchingLeft
    {
        get
        {
            return leap.IsPinchingLeft || leap.IsPinchingBoth;
        }
    }

    public bool IsPinchingRight
    {
        get
        {
            return leap.IsPinchingRight || leap.IsPinchingBoth;
        }
    }

    public bool IsPinchingBoth
    {
        get
        {
            return leap.IsPinchingBoth;
        }
    }
}
