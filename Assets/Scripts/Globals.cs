/***
*
* 插件：虚拟现实汽车仿真开--全局脚本
*
* 功能：项目中所有大的功能模块之间进行数据传递
*
* 作者:
*
* Version: 1.0
*
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  namespace CarSimulation
{
    #region 项目中所有的枚举类型定义区域

    //旋转方向
    public enum RotateDiretion
    {
        None,
        RotateDown,
        RotateLeft,
        RotateRight,
        RotateForword,
        RotateBack
    }

    //操作状态(用户的功能选项)
    public enum OperationState
    {
        None,
        RemoveObj,            //拆卸汽车零部件
        MakeRuning,           //使运行（汽车零部件）
        PaintCarParts,        //汽车零部件喷漆
        AutoDriver           //自动驾驶
    }

    //UI汽车颜色
    public enum UICarColor
    {
        None,
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }
    #endregion

    public static class Globals 
    {
        //用户操作类型
        public static OperationState CurrentOperationState = OperationState.None;
        //用户选择的汽车喷漆颜色
        public static UICarColor CurrentPaintColor = UICarColor.None;

        /*常用的标签常量*/



    }
}