using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using kernal;

public class Ctrl_HeroAttackInputByKey : BaseControl {
    public static event del_PlayerControlWithStr evePlayerControl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL))
        {
            //print("j");
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL);
            }
        }
        else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A))
        {
            //print("k");
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_A);
            }
        }
        else if (Input.GetButtonDown(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B))
        {
            //print("l");
            if (evePlayerControl != null)
            {
                evePlayerControl(GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICK_B);
            }
        }
    }
}
