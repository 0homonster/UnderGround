using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//定义整个项目枚举类型
//定义整个项目委托，系统常量
namespace Global
{

    public class GlobalParameter
    {
        public const string INPUT_MGR_ATTACKNAME_NORMAL = "NormalAttack";
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_A = "MagicTrickA";
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICK_B = "MagicTrickB";




    }
    public enum ScenesEnum
    {
        StartScenes,
        LoadingScenes,
        LongonScenes,
        LevelOne,
        LevelTwo,
        BaseScenes
    }
    public enum PlayerType
    {
        SwordHero,
        MagicHero,
        Other
    }
    public enum HeroActionState
    {
        None,
        Idle,
        Running,
        NormalAttack,
        MagicTrickA,
        MagicTrickB 
    }
   public enum NormalATKComboState
    {
        NormalATK1,
        NormalATK2,
        NormalATK3,
    }

    public delegate void del_PlayerControlWithStr(string controlType);
}
