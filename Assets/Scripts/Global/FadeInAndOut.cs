using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//脚本控制透明度达到淡入淡出的效果
namespace Global
{
    public class FadeInAndOut : MonoBehaviour
    {
        public static FadeInAndOut Instance;      //本类实例
        public float FloColorChangeSpeed = 1F;    //颜色变化速度
        public GameObject goRawImage;             //RawImage对象(整个）
        private RawImage _RawImage;               //RawImage组件
        private bool _BoolScenesToClear = true;   //屏幕逐渐清晰
        private bool _BoolScenesToBlack = false;  //屏幕逐渐变暗
        private void Awake()
        {
            //得到本类实例
            Instance = this;
            if (goRawImage)
            {
                _RawImage = goRawImage.GetComponent<RawImage>();
            }
        }
        //设置场景的淡入
        public void SetScenesToClear()
        {
            _BoolScenesToClear = true;
            _BoolScenesToBlack = false;
        }
        //设置场景淡出
        public void SetScenesToBlack()
        {
            _BoolScenesToClear = false;
            _BoolScenesToBlack = true;
        }
        //淡入，屏幕逐渐清晰
        private void FadeToClear()
        {
            //运用Color的插值计算
            _RawImage.color = Color.Lerp(_RawImage.color, Color.clear,FloColorChangeSpeed*Time.deltaTime);
        }
        //淡出效果，屏幕逐渐暗淡
        private void FadeToBlack()
        {
            _RawImage.color = Color.Lerp(_RawImage.color, Color.black, FloColorChangeSpeed * Time.deltaTime);
        }
        //屏幕淡入
        private void ScenesToClear()
        {
            FadeToClear();
            if (_RawImage.color.a<=0.05)
            {
                _RawImage.color = Color.clear;
                _RawImage.enabled = false;
                _BoolScenesToClear = false;
            }
        }
        //屏幕淡出
        private void ScenesToBlack()
        {
            _RawImage.enabled = true;
            FadeToBlack();
            if (_RawImage.color.a >= 0.95)
            {
                _RawImage.color = Color.black;
                _BoolScenesToBlack = false;
            }
        }
        private void Update()
        {
            if (_BoolScenesToClear)
            {
                //屏幕淡入
                ScenesToClear();
            }
            else if (_BoolScenesToBlack)
            {
                //屏幕淡出
                ScenesToBlack();
            }
        }
    }
}
