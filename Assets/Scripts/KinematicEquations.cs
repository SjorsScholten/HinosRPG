using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicEquations {
   
    #region Calculate Displacement
    public static float SUVA(float u, float v, float a) {
        float s = (Mathf.Pow(v, 2) - Mathf.Pow(u, 2)) / a;
        return s;
    }

    public static float SUVT(float u, float v, float t) {
        float s = (u + v) / 2 * t;
        return s;
    }

    public static float SUAT(float u, float a, float t) {
        float s = u * t + (a * Mathf.Pow(t, 2)) / 2;
        return s;
    }

    public static float SVAT(float v, float a, float t) {
        float s = v * t - (a * Mathf.Pow(t, 2)) / 2;
        return s;
    }
    #endregion

    #region Calculate Initial Velocity
    public static float USVA(Vector2 s, float v, float a) {
        float u = Mathf.Pow(v, 2) - 2 * a * s.magnitude;
        return Mathf.Sqrt(u);
    }

    public static float USAT(Vector2 s, float a, float t) {
        float u = (2 * s.magnitude - (a * Mathf.Pow(t, 2))) / 2 * t;
        return u;
    }

    public static float USVT(Vector2 s, float v, float t) {
        float u = 2 * (s.magnitude / t) - v;
        return u;
    }

    public static float UAVT(float a, float v, float t) {
        float u = v - a * t;
        return 0;
    }
    #endregion

    #region Calculate Final Velocity
    public static float VSUA(Vector2 s, float u, float a) {
        float v = Mathf.Sqrt(u) + 2 * a * s.magnitude;
        return Mathf.Sqrt(v);
    }

    public static float VSUT(Vector2 s, float u, float t) {
        float v = 0;
        return v;
    }

    public static float VSAT(Vector2 s, float a, float t) {
        float v = 0;
        return v;
    }

    public static float VUAT(float u, float a, float t) {
        float v = u + a * t;
        return v;
    }
    #endregion

    #region Calculate Acceleration
    public static float ASUV() {
        float a = 0;
        return a;
    }

    public static float ASUT(Vector2 s, float u, float t) {
        float a = 2 * s.magnitude * Mathf.Pow(t, 2) - 2 * u * t * Mathf.Pow(t, 2);
        return a;
    }

    public static float ASVT() {
        float a = 0;
        return a;
    }

    public static float AUVT(float v, float u, float t) {
        float a = (v - u) / t;
        return a;
    }
    #endregion

    #region Calculate Time

    #endregion
}
