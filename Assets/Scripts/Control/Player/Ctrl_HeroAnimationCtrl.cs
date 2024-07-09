using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using kernal;

public class Ctrl_HeroAnimationCtrl : MonoBehaviour {
    public static Ctrl_HeroAnimationCtrl Instance;
    private HeroActionState _CurrentActionState = HeroActionState.None;
    public AnimationClip Ani_Idle;
    public AnimationClip Ani_Running;
    public AnimationClip Ani_NormalAttack1;
    public AnimationClip Ani_NormalAttack2;
    public AnimationClip Ani_NormalAttack3;
    public AnimationClip Ani_MagicTrickA;
    public AnimationClip Ani_MagicTrickB;
    //动画句柄
    private Animation _AnimationHandle;
    //定义动画单次开关
    private bool _IsSinglePlay = true;
    private NormalATKComboState _CurATKCombo = NormalATKComboState.NormalATK1;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
        _CurrentActionState = HeroActionState.Idle;
        _AnimationHandle = this.GetComponent<Animation>();
        StartCoroutine("ControlHeroAnimationState");
        //加快普通连招的播放速度
        _AnimationHandle[Ani_NormalAttack1.name].speed = 2.5f;
        _AnimationHandle[Ani_NormalAttack2.name].speed = 2.5f;
        _AnimationHandle[Ani_NormalAttack3.name].speed = 2f;
    }
	
	// Update is called once per frame
    
    public void SetCurrentActionState(HeroActionState currentActionState)
    {
        _CurrentActionState = currentActionState;
    }

    IEnumerator ControlHeroAnimationState()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            switch (_CurrentActionState)
            {
                case HeroActionState.None:
                    break;
                case HeroActionState.Idle:
                    _AnimationHandle.CrossFade(Ani_Idle.name);
                    break;
                case HeroActionState.Running:
                    _AnimationHandle.CrossFade(Ani_Running.name);
                    break;
                case HeroActionState.NormalAttack:

                    switch (_CurATKCombo)
                    {
                        case NormalATKComboState.NormalATK1:
                            _CurATKCombo = NormalATKComboState.NormalATK2;
                            if (_IsSinglePlay)
                            {
                                _IsSinglePlay = false;
                                _AnimationHandle.CrossFade(Ani_NormalAttack1.name);
                                yield return new WaitForSeconds(Ani_NormalAttack1.length/2.5f);
                            }
                            else
                            {
                                //恢复为休闲状态
                                StartCoroutine("ReturnOriginalAction");
                            }
                            break;
                        case NormalATKComboState.NormalATK2:
                            _CurATKCombo = NormalATKComboState.NormalATK3;
                            if (_IsSinglePlay)
                            {
                                _IsSinglePlay = false;
                                _AnimationHandle.CrossFade(Ani_NormalAttack2.name);
                                yield return new WaitForSeconds(Ani_NormalAttack2.length/2.5f);
                            }
                            else
                            {
                                //恢复为休闲状态
                                StartCoroutine("ReturnOriginalAction");
                            }
                            break;
                        case NormalATKComboState.NormalATK3:
                            _CurATKCombo = NormalATKComboState.NormalATK1;
                            if (_IsSinglePlay)
                            {
                                _IsSinglePlay = false;
                                _AnimationHandle.CrossFade(Ani_NormalAttack3.name);
                                yield return new WaitForSeconds(Ani_NormalAttack3.length/2f);
                            }
                            else
                            {
                                //恢复为休闲状态
                                StartCoroutine("ReturnOriginalAction");
                            }
                            break;
                        default:
                            break;

                    }
                    break;
                case HeroActionState.MagicTrickA:
                    if (_IsSinglePlay)
                    {
                        _IsSinglePlay = false;
                        _AnimationHandle.CrossFade(Ani_MagicTrickA.name);
                        yield return new WaitForSeconds(Ani_MagicTrickA.length);
                    }
                    else
                    {
                        //恢复为休闲状态
                        StartCoroutine("ReturnOriginalAction");
                    }
                    break;
                case HeroActionState.MagicTrickB:
                    if (_IsSinglePlay)
                    {
                        _IsSinglePlay = false;
                        _AnimationHandle.CrossFade(Ani_MagicTrickB.name);
                        yield return new WaitForSeconds(Ani_MagicTrickB.length);
                    }
                    else
                    {
                        //恢复为休闲状态
                        StartCoroutine("ReturnOriginalAction");
                    }
                    break;
                default:
                    break;
            }
        }
    }
    IEnumerator ReturnOriginalAction()
    {
        _CurrentActionState = HeroActionState.Idle;
        yield return new WaitForSeconds(0.05f);
        _IsSinglePlay = true;
    }
}
