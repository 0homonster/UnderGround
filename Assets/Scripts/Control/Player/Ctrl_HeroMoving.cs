using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;
using kernal;

public class Ctrl_HeroMoving : BaseControl
{
    //public AnimationClip idle;
    //public AnimationClip run;

    //角色控制器
    private CharacterController cc;
    //模拟重力
    float gravity = 1f;
    private void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {

            transform.LookAt(new Vector3(transform.position.x - hor, transform.position.y, transform.position.z - ver));
            //transform.Translate(Vector3.forward * Time.deltaTime * 5);
            Vector3 dir = transform.forward * Time.deltaTime * 5;
            dir.y -= gravity;
            cc.Move(dir);
            //ani.CrossFade(run.name);
            Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.Running);


        }
        else
        {
            //ani.CrossFade(idle.name);
            Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(HeroActionState.Idle);
        }
    }
}