using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;

//开始场景
namespace Control
{
    public class Ctrl_StartScenes : MonoBehaviour
    {
        public static Ctrl_StartScenes Instance;//本类实例
        public AudioClip AucBackground;//背景音乐音频剪辑
        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            //设置音频音量
            AudioManager.SetAudioBackgroundVolumns(0.5F);
            AudioManager.SetAudioEffectVolumns(1F);
            //播放背景音乐
            AudioManager.PlayBackground(AucBackground);
        }
        //点击新游戏
        internal void ClickNewGame()
        {
            print(GetType() + " ClickNewGame");
            //进入登录
            StartCoroutine("EnterNextScenes");
        }
        //点击游戏继续
        internal void ClickGameContinue()
        {
            print(GetType() + "ClickGameContinue");
        }
        //进入下一个场景
         IEnumerator  EnterNextScenes()
        {
            //场景淡出
            FadeInAndOut.Instance.SetScenesToBlack();//设置场景为淡出效果
            yield return new WaitForSeconds(1.5F);
            //跳转下个场景
            GlobalParaMgr.NextScenesName = ScenesEnum.LongonScenes;//转到登录场景
            Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(ScenesEnum.LoadingScenes));
        }
    }
}
