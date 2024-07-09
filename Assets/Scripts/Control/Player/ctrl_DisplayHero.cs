using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrl_DisplayHero : MonoBehaviour {

    public AnimationClip AniIdle;
    public AnimationClip AniRuning;
    public AnimationClip AniAttack;
    private Animation _AniCurrentAnimation;
    private float _FloIntervalTimes = 3f;
    private int _intRandomPlayNum;
	// Use this for initialization
	void Start () {
        _AniCurrentAnimation = this.GetComponent<Animation>();
	}
    //算法：间隔3s随机播放一个人物动作
    void Update()
    {
        _FloIntervalTimes -= Time.deltaTime;
        if (_FloIntervalTimes<=0)
        {
            _FloIntervalTimes = 3f;
            _intRandomPlayNum = Random.Range(1, 4);
            DisplayHeroPlaying(_intRandomPlayNum);
        }
    }

    internal void DisplayHeroPlaying(int intPlayingNum)
    {
        switch (intPlayingNum)
        {
            case 1:
                DisplayIdle();
                break;
            case 2:
                DisplayRuning();
                break;
            case 3:
                DisplayAttack();
                break;
            default:
                break;
        }
    }


    //展示休闲动作
    internal void DisplayIdle()
    {
        if (_AniCurrentAnimation)
        {
            _AniCurrentAnimation.CrossFade(AniIdle.name);
        }
    }
    //展示跑动动作
    internal void DisplayRuning()
    {
        if (_AniCurrentAnimation)
        {
            _AniCurrentAnimation.CrossFade(AniRuning.name);
        }
    }
    //展示攻击动作
    internal void DisplayAttack()
    {
        if (_AniCurrentAnimation)
        {
            _AniCurrentAnimation.CrossFade(AniAttack.name);
        }
    }
}
