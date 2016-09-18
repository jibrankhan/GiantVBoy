using UnityEngine;
using System.Collections;

public class ColorBall : MonoBehaviour {

    // public settings for colorball
    public Transform normalEffect;
    public Transform rainEffect;
    public Transform rainSqueezeEffect;
    public Transform lightningEffect;
    public Transform lightningSqueezeEffect;
    public Material normalMat, rainMat, rainSqueezeMat, lightningMat, lightningSqueezeMat;

    // enum classes
    public enum State { Normal, Rain, RainSqueeze, Lightning, LightningSqueeze };
    public enum AnimState { Bigger, Normal, Smaller};
    
    // state variables
    static bool matChanged;
    int animCount;
    const int maxAnim = 12;
    static AnimState animState;
    float offset = 0.02f;
    float scale = 1;
    Transform effectObject;

    static State currentState;
    // Use this for initialization
    void Start() {
        currentState = State.Normal;
        matChanged = false;
        animCount = 12;
        transform.localScale = new Vector3(1, 1, 1);
        animState = AnimState.Normal;
    }

    // Update is called once per frame
    void Update() {
        if (matChanged)
        {
            Renderer rend = GetComponent<Renderer>();
            if (effectObject)
            {
                Destroy(effectObject.gameObject);
            }
            switch (currentState)
            {
                case State.Normal:
                    rend.material = normalMat;
                    effectObject = Instantiate(normalEffect, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
                    break;

                case State.Rain:
                    rend.material = rainMat;
                    effectObject = Instantiate(rainEffect, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
                    break;

                case State.RainSqueeze:
                    rend.material = rainSqueezeMat;
                    effectObject = Instantiate(rainSqueezeEffect, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
                    break;

                case State.Lightning:
                    rend.material = lightningMat;
                    effectObject = Instantiate(lightningEffect, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
                    break;

                case State.LightningSqueeze:
                    rend.material = lightningSqueezeMat;
                    effectObject = Instantiate(lightningSqueezeEffect, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
                    break;
                default:
                    break;
            }
            effectObject.parent = transform;
            effectObject.transform.position= transform.position;
            matChanged = false;
        }
        
        if(animCount > 0)
        {
            if(animState == AnimState.Bigger)
            {
                transform.localScale += new Vector3(offset, offset, offset);
                animCount--;
            }
            else if(animState == AnimState.Smaller)
            {
                transform.localScale -= new Vector3(offset, offset, offset);
                animCount--;
            }
        }
        else if(animCount == 0)
        {
            animState = AnimState.Normal;
            animCount = maxAnim;
        }

       }

    public static void setState(State newState)
    {
        currentState = newState;
        matChanged = true;
    }

    public static void setAnim(AnimState _animState)
    {
        animState = _animState;
    }
  }
    
