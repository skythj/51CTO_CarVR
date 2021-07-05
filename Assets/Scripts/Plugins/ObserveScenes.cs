/*
 *
 *  Title:     摄像机控制脚本
 *
 *  Descripts: 
 *          [详细描述本脚本的作用]
 *
 *  Author: Liu guozhu
 *
 *  Version: 0.1
 *
 */
using UnityEngine;
using System.Collections;


namespace CarSimulation
{
    public class ObserveScenes : MonoBehaviour
    {
        /* 摄像机的旋转处理  */
        public Transform Target;                                                   //摄像机参照的模型
        public float Distance = 20.0f;                                             //摄像机距离模型的默认距离
        public float MinRotationLimit_Y = -20.0f;                                  //限制旋转角度的最小与最大数值
        public float MaxRotationLimit_Y = 90.0f;
        public float MouseMovingSpeed_X = 250.0f;                                  //鼠标在x和y轴方向移动的速度
        public float MouseMovingSpeed_Y = 120.0f;
        private float _CameraMovingRotation_X;                                     //鼠标在x轴和y轴方向的移动的角度
        private float _CameraMovingRotation_Y;

        /* 摄像机的推拉（远近）处理 */
        public LayerMask RayLayerMask;                                             //射线层
        //private float scrollSpeed = 100f;
        //备注： 以下的 10，30 代表射线机Y轴与被观察物体的高度范围，且要求摄像机的
        //旋转数值参数必须设定为： X=39.84 Y=0.0  Z=0.0  (这个结果可以保证transform.forword= 0.0,  -0.6,  0.8)
        public Vector2 ZoomRange = new Vector2(10, 30);                            //摄像机的推进范围（摄像机Y轴高度范围）
        public float ZoomSpeed = 1f;                                               //摄像机推进拉远速度的比率。
        private float _CurrentZoom = 0;                                            //摄像机当前速率。


        //void Start()
        //{
        //   
        //}//Start_end

        void LateUpdate()
        {
            //摄像机的旋转处理
            if (Input.GetMouseButton(1))
            {
                CameraRotation();
            }
            //摄像机镜头推拉（远近）处理
            else
            {
                ScrollWheel();
            }
        }//LateUpdate_end

        //摄像机旋转处理
        internal void CameraRotation()
        {
            if (Target)
            {
                //根据鼠标移动修改摄像机的角度
                _CameraMovingRotation_X += Input.GetAxis("Mouse X") * MouseMovingSpeed_X * 0.02f;
                _CameraMovingRotation_Y -= Input.GetAxis("Mouse Y") * MouseMovingSpeed_Y * 0.02f;
                //鼠标的上下运动进行受限（范围）处理
                _CameraMovingRotation_Y = ClampAngle(_CameraMovingRotation_Y, MinRotationLimit_Y, MaxRotationLimit_Y);
                //以世界坐标系，进行旋转处理。
                Quaternion rotation = Quaternion.Euler(_CameraMovingRotation_Y, _CameraMovingRotation_X, 0);
                //摄像机位移处理 （？？？）
                Vector3 position = rotation * new Vector3(0.0f, 0.0f, -Distance) + Target.position;
                //设置摄像机的位置与旋转
                transform.rotation = rotation;
                transform.position = position;
            }
        }
        //角度受限修正
        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }

        //推进与拉远摄像机
        internal void ScrollWheel()
        {
            //currentZoom >0 为拉近。（滚轮向上），<0 则为离远（滚轮向下）
            _CurrentZoom = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomSpeed;
            if (Mathf.Abs(_CurrentZoom) > 0)
            {
                Vector3 pos = transform.position;
                Vector3 dir = transform.forward * _CurrentZoom;
                Vector3 targetPos = pos + dir;

                if (targetPos.y < ZoomRange.x)                                 //防止镜头离得太近
                {
                    float scale = Mathf.Clamp01((ZoomRange.x - pos.y) / (targetPos.y - pos.y));
                    dir = transform.forward * _CurrentZoom * scale;
                }
                else if (targetPos.y > ZoomRange.y)                            //防止镜头拉的太远
                {
                    float scale = Mathf.Clamp01((ZoomRange.y - pos.y) / (targetPos.y - pos.y));
                    dir = transform.forward * _CurrentZoom * scale;
                }

                if (CheckBounds(dir))
                {
                    transform.position = pos + dir;
                }
            }//if_end
        }//ScrollWheel_end

        //滑动阻尼检查。
        private bool CheckBounds(Vector3 direction)
        {
            if (Physics.Raycast(transform.position, direction, 10, RayLayerMask))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }//Class_end
}//LiuMobilGameLib.CameraControls_end
