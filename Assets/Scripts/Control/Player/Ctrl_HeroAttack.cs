using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;
using kernal;

public class Ctrl_HeroAttack : BaseControl {

    private void Awake()
    {
        Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseNormalAttack;
        Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseMagicTrickA;
        Ctrl_HeroAttackInputByKey.evePlayerControl += ResponseMagicTrickB;
    }
    // Use this for initialization
   public void ResponseNormalAttack(string controlType)
    {
        if(controlType == "NormalAttack")
        {
            Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.NormalAttack);
        }
    }
    public void ResponseMagicTrickA(string controlType)
    {
        if (controlType == "MagicTrickA")
        {
            Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.MagicTrickA);
        }
    }
    public void ResponseMagicTrickB(string controlType)
    {
        if (controlType == "MagicTrickB")
        {
            Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.MagicTrickB);
        }
    }
}
