using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
///球面坐标和平面坐标的转换公式
/// </summary>
public class AirCraftsManager 
{
  
   

    #region 经纬转球面坐标


    float Torad(float deg)
    {
        return deg / 180 * Mathf.Acos(-1);
    }

    public Vector3 GetPosFromGraticles(float lat, float longt, float rad)
    {
        lat = Torad(lat);
        longt = Torad(longt);
        float x = rad * Mathf.Cos(lat) * Mathf.Cos(longt);
        float z = rad * Mathf.Cos(lat) * Mathf.Sin(longt);
        float y = rad * Mathf.Sin(lat);

        return new Vector3(x, y, z);

    }

    Vector2 GetGraticlesFromPos(Vector3 cood)
    {
        float r = cood.magnitude;
        float lat = Mathf.Asin(cood.z / r) * Mathf.Rad2Deg;//转成度
        float longt = Mathf.Atan2(cood.y, cood.x) * Mathf.Rad2Deg;

        return new Vector2(lat, longt);
    }


    #endregion

    #region 经纬转平面坐标(米勒坐标投影)

    public Vector2 MillierConvertion(float lat, float lon)
    {
        int plotscale = 1;
        float L = 6381372 * Mathf.PI * 2;//地球周长  
        float W = L;// 平面展开后，x轴等于周长  
        float H = L / 2;// y轴约等于周长一半  
        float mill = 2.3f;// 米勒投影中的一个常数，范围大约在正负2.3之间  
        float x = lon * Mathf.PI / 180;// 将经度从度数转换为弧度  
        float y = lat * Mathf.PI / 180;// 将纬度从度数转换为弧度  
        y = 1.25f * Mathf.Log(Mathf.Tan(0.25f * Mathf.PI + 0.4f * y));// 米勒投影的转换  
                                                                      // 弧度转为实际距离  
        x = (W / 2) + (W / (2 * Mathf.PI)) * x;
        y = (H / 2) - (H / (2 * mill)) * y;
        // double* result = new double[2];
        // result[0] = (int)x;
        // result[1] = (int)y;
        Vector2 vec2 = new Vector2((int)x, (int)y);
        return vec2 / plotscale;
    }


    Vector2 MillierConvertion1(float x, float y)
    {
        float L = 6381372 * Mathf.PI * 2;//地球周长  
        float W = L;// 平面展开后，x轴等于周长  
        float H = L / 2;// y轴约等于周长一半  
        float mill = 2.3f;// 米勒投影中的一个常数，范围大约在正负2.3之间  
        float lat;
        lat = ((H / 2 - y) * 2 * mill) / (1.25f * H);
        lat = ((Mathf.Atan(Mathf.Exp(lat)) - 0.25f * Mathf.PI) * 180) / (0.4f * Mathf.PI);
        float lon;
        lon = (x - W / 2) * 360 / W;
        //double* result = new double[2];
        //result[0] = lon;
        //result[1] = lat;
        Vector2 vec2 = new Vector2(lat, lon);
        return vec2;
    }

    #endregion

   

}
