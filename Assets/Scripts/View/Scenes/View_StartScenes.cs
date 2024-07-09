using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Control;

namespace View {
    public class View_StartScenes : MonoBehaviour
    {
        //新的游戏
        public void ClickNewGame()
        {
            print(GetType() + " ClickNewGame");
            //调用控制层开始场景方法进入新游戏
            Ctrl_StartScenes.Instance.ClickNewGame();
        }
        //游戏继续
        public void ClickGameContinue()
        {
            print(GetType() + "ClickGameContinue");
            Ctrl_StartScenes.Instance.ClickGameContinue();
        }
    }
}
