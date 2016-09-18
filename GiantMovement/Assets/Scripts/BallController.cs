using UnityEngine;
using System.Collections;


// Example to switch the ball status 
public class BallController : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
        if (Input.GetKeyDown("1")){
            ColorBall.setState(ColorBall.State.Normal);
            ColorBall.setAnim(ColorBall.AnimState.Smaller);
        }
        else if (Input.GetKeyDown("2")){
            ColorBall.setState(ColorBall.State.Rain);
            ColorBall.setAnim(ColorBall.AnimState.Bigger);
        }
        else if(Input.GetKeyDown("3")){
            ColorBall.setState(ColorBall.State.RainSqueeze);
        }
        else if (Input.GetKeyDown("4"))
        {
            ColorBall.setState(ColorBall.State.Lightning);
            ColorBall.setAnim(ColorBall.AnimState.Bigger);

        }
        else if (Input.GetKeyDown("5"))
        {
            ColorBall.setState(ColorBall.State.LightningSqueeze);
        }

	}
}
