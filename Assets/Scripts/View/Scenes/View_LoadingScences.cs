using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;

//场景异步加载控制
namespace View
{
    public class View_LoadingScences : MonoBehaviour
    {
        public Slider SliLoadingProgress;   //进度条控件
        private float _FloProgressNumber;    //进度数值
        private AsyncOperation _AsyOper;
        void Start()
        {
            StartCoroutine("LoadingScenesProgress");
        }
        //异步加载
        IEnumerator LoadingScenesProgress()
        {
            _AsyOper = Application.LoadLevelAsync(ConvertEnumToStr.GetInstance().GetStrByEnumScenes(GlobalParaMgr.NextScenesName));
            _FloProgressNumber = _AsyOper.progress;
            yield return _AsyOper;
        }

         void Update()
        {
            if (_FloProgressNumber <= 1)
            {
                _FloProgressNumber += 0.01F;
            }
            SliLoadingProgress.value = _FloProgressNumber;
        }
    }
}
