/***
*
* 插件：虚拟现实汽车仿真开--射线技术检测汽车零部件
*
* 功能：使用射线技术，检测定位的汽车零部件名称
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
    public class RaycastToObj : MonoBehaviour
    {

        void Start()
        {

        }

         
        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                //定义射线的核心编码
                //从主摄像机位置到屏幕点击的方位，发射射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //print("返回3D坐标"+hit.point);//返回射线碰撞到碰撞体的3D方位     
                    //print("返回3D对象" + hit.collider.gameObject.name);
                    //过滤无用的碰撞体
                    if(hit.collider.gameObject.tag=="Tag_CarParts")
                    {
                        //print("返回我们需要的3D对象" + hit.collider.gameObject.name);
                        //判断用户的操作状态
                        switch (Globals.CurrentOperationState)
                        {
                            case OperationState.None:
                                break;
                                //卸载汽车零部件 
                            case OperationState.RemoveObj:
                                break;
                                //
                            case OperationState.MakeRuning:
                                break;
                            case OperationState.PaintCarParts:
                                break;
                            case OperationState.AutoDriver:
                                break;
                            default:
                                break;
                        }
                    }  
                     
                }
            }

        }
    }
}
 
 