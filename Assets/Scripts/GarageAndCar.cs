/***
*
* 插件：虚拟现实汽车仿真开发-车库与汽车三大件管理
*
* 功能：项目中全局性的功能实现
*       A. 车库门的启闭；
*       B. 显示汽车三大件；
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
    public class GarageAndCar : MonoBehaviour
    {
        //public GameObject GoGarageDoor;    //车库门 
        public GameObject GoCarBody;       //车体
        public GameObject GoSuspending;    //汽车悬挂系统
        public GameObject GoEngin;         //汽车发动机

        //显示车体

        public void ShowCarBody()
        {
            GoCarBody.SetActive(true);
            GoSuspending.SetActive(false);
            GoEngin.SetActive(false);
        }

        //显示发动机
        public void ShowEngine()
        {
            GoCarBody.SetActive(false);
            GoSuspending.SetActive(false);
            GoEngin.SetActive(true);
        }

        //显示先挂系统
        public void ShowSuspending()
        {
            GoCarBody.SetActive(false);
            GoSuspending.SetActive(true);
            GoEngin.SetActive(false);
        }

        //显示全部
        public void ShowALL()
        {
            GoCarBody.SetActive(true);
            GoSuspending.SetActive(true);
            GoEngin.SetActive(true);
        }


        // Start is called before the first frame update
        void Start()
        {
            //参数检查
            if(GoCarBody==null || GoSuspending == null || GoEngin==null)
            {
                Debug.LogError(GetType()+"字段没有赋值，请检查");
            }
        }

      
    }
}
