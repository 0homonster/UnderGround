using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Global
{
    public class ConvertEnumToStr
    {
        private static ConvertEnumToStr _Instance;//本例实例
        //枚举场景类型集合
        private Dictionary<ScenesEnum, string> _DicScenesEnumLib;
        //构造函数
        private ConvertEnumToStr()
        {
            _DicScenesEnumLib = new Dictionary<ScenesEnum, string>();
            _DicScenesEnumLib.Add(ScenesEnum.StartScenes, "1_StartScenes");
            _DicScenesEnumLib.Add(ScenesEnum.LongonScenes, "2_LogonScenes");
            _DicScenesEnumLib.Add(ScenesEnum.LoadingScenes, "LoadingScenes");
        }
        //得到实例，单例模式应用
        public static ConvertEnumToStr GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new ConvertEnumToStr();
            }
            return _Instance;
        }
        //得到字符串形式的场景名称
        //输入枚举类型的场景名称
         public string GetStrByEnumScenes(ScenesEnum scenesEnum)
        {
            if (_DicScenesEnumLib!=null&& _DicScenesEnumLib.Count>=1)
            {
                return _DicScenesEnumLib[scenesEnum];
            }
            else
            {
                Debug.LogWarning(GetType() + "/GetStrByEnumScenes()/_DicScenesEnumLib.count<=0 !,please check!");
                return null;
            }
        }
    }
}
