/***
*
* 插件：虚拟现实汽车仿真开发-项目管理器
*
* 功能：项目中全局性的功能实现
*       A. 项目的生命周期管路；
*       B. 汽车主要零部件管理；
*       C. 项目的UI管理；
*       D. 切换摄像机；
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
    public class ProjectManger : MonoBehaviour
    {
        /*UI菜单*/
        public GameObject GoUIMenu;          //车库UI 菜单
        public Transform TrUIMenuShowPos;    //车库UI菜单显示方位  
        public Transform TrUIMenuHidePos;    //车库UI菜单隐藏方位

        /*汽车部件*/
        public GameObject GoCarPrefab;      //汽车预设
        public Transform TrCarPrefab;       //汽车预设访问


        void Start()
        {
            //汽车显示
            if(GoCarPrefab!=null && TrCarPrefab!=null)
            {
                GoCarPrefab.transform.position = TrCarPrefab.position;
            }
        }

        //显示UI 菜单
        public void ShowUIMenuByGarage()
        {
            iTween.MoveTo(GoUIMenu, TrUIMenuShowPos.position, 5F);
            
        }

        //隐藏UI 菜单
        public void HideUIMenuByGarage()
        {
            iTween.MoveTo(GoUIMenu,TrUIMenuHidePos.position,5F);
        }

        void Update()
        {

        }
    }

}
