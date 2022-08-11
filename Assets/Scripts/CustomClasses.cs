using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomClasses
{
    #region Extentions

    public static Vector2 Abs(this Vector2 a) => new Vector2(Mathf.Abs(a.x), Mathf.Abs(a.y));

    public static Vector3 Abs(this Vector3 a) => new Vector3(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));

    public static float AsAngle(this Vector2 a) => Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg;

    public static float AsAngle(this Vector3 a) => Mathf.Atan2(a.x, a.z) * Mathf.Rad2Deg;

    public static Vector2 AsVector2(this float a) => new Vector2(Mathf.Cos(a * Mathf.Deg2Rad), Mathf.Sin(a * Mathf.Deg2Rad));

    public static Vector3 AsVector3(this Vector2 a) => new Vector3(a.x, a.y);

    public static Vector2 AsVector2(this Vector3 a) => new Vector2(a.x, a.y);

    public static Vector2 RemoveX(this Vector2 a) => new Vector2(0f, a.y);

    public static Vector2 RemoveY(this Vector2 a) => new Vector2(a.x, 0f);

    public static Vector3 RemoveX(this Vector3 a) => new Vector3(0f, a.y, a.z);

    public static Vector3 RemoveY(this Vector3 a) => new Vector3(a.x, 0f, a.z);

    public static Vector3 RemoveZ(this Vector3 a) => new Vector3(a.x, a.y, 0f);

    public static Vector2 ReplaceX(this Vector2 a, float b) => new Vector2(b, a.y);

    public static Vector2 ReplaceY(this Vector2 a, float b) => new Vector2(a.x, b);

    public static Vector3 ReplaceX(this Vector3 a, float b) => new Vector3(b, a.y, a.z);

    public static Vector3 ReplaceY(this Vector3 a, float b) => new Vector3(a.x, b, a.z);

    public static Vector3 ReplaceZ(this Vector3 a, float b) => new Vector3(a.x, a.y, b);

    public static Vector2 SwapXY(this Vector2 a) => new Vector2(a.y, a.x);

    public static Vector2 Make2d(this Vector3 a) => new Vector2(a.x, a.z);

    public static Vector3 Make3d(this Vector2 a) => new Vector3(a.x, 0f, a.y);

    public static Color ReplaceA(this Color a, float b) => new Color(a.r, a.g, a.b, b);

    public static Transform[] GetChildAll(this Transform a) => GetAllChildrenRecursive(a).ToArray();

    public static GameObject[] GetChildAll(this GameObject a) => GetAllChildrenRecursive(a).ToArray();

    public static Component[] GetComponentAll(this Transform a, System.Type type) => GetAllComponentsFromList(GetAllChildrenRecursive(a), type).ToArray();

    public static Component[] GetComponentAll(this GameObject a, System.Type type) => GetAllComponentsFromList(GetAllChildrenRecursive(a.transform), type).ToArray();

    public static void Align(this Transform a, Transform b) { a.position = b.position; a.rotation = b.rotation; }

    public static void Align(this Transform[] a, Transform[] b) { for (int i = 0; i < Mathf.Min(a.Length, b.Length); i++) { a[i].Align(b[i]); } }

    // Testing Needed
    public static Quaternion TransformRotation(this Transform a, Quaternion b) => a.rotation * b;

    // Testing Needed 
    public static Quaternion InverseTransformRotation(this Transform a, Quaternion b) => Quaternion.Inverse(a.rotation) * b;

    #endregion Extentions

    #region Functions

    public static Vector2 DivideScale(Vector2 a, Vector2 b) => new Vector2(DivideSafe(a.x, b.x), DivideSafe(a.y, b.y));

    public static Vector3 DivideScale(Vector3 a, Vector3 b) => new Vector3(DivideSafe(a.x, b.x), DivideSafe(a.y, b.y), DivideSafe(a.z, b.z));

    public static float DivideSafe(float a, float b)
    {
        var output = a / b;

        if (output == float.NaN)
            return 0f;

        return output;
    }

    public static float ClampAbsolute(float value, float max)
    {
        return Mathf.Clamp(value, -Mathf.Abs(max), Mathf.Abs(max));
    }

    public static float RepeatAbsolute(float value, float max)
    {
        max = Mathf.Abs(max);

        if (value < -max)
        {
            value += max * 2f;
        }
        else if (value > max)
        {
            value -= max * 2f;
        }

        return value;
    }

    public static float MinAbsolute(float a, float b)
    {
        return Mathf.Abs(a) < Mathf.Abs(b) ? a : b;
    }

    public static float MaxAbsolute(float a, float b)
    {
        return Mathf.Abs(a) > Mathf.Abs(b) ? a : b;
    }

    public static Vector2 DeltaAngle(Vector2 current, Vector2 target)
    {
        return new Vector2(Mathf.DeltaAngle(current.x, target.x), Mathf.DeltaAngle(current.y, target.y));
    }

    public static Vector2 MoveTowardsAngle(Vector2 current, Vector2 target, float maxDelta)
    {
        var deltas = DeltaAngle(current, target).normalized.Abs();

        return new Vector2(Mathf.MoveTowardsAngle(current.x, target.x, maxDelta * deltas.x), Mathf.MoveTowardsAngle(current.y, target.y, maxDelta * deltas.y));
    }

    public static float Damp(float a, float b, float lambda, float dt)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }

    public static Vector2 Damp(Vector2 a, Vector2 b, float lambda, float dt)
    {
        return Vector2.Lerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }

    public static Vector3 Damp(Vector3 a, Vector3 b, float lambda, float dt)
    {
        return Vector3.Lerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }

    public static Quaternion Damp(Quaternion a, Quaternion b, float lambda, float dt)
    {
        return Quaternion.Lerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }

    public static float DampAngle(float a, float b, float lambda, float dt)
    {
        return Mathf.LerpAngle(a, b, 1 - Mathf.Exp(-lambda * dt));
    }

    public static Vector2 DampAngle(Vector2 a, Vector2 b, float lambda, float dt)
    {
        return new Vector2(
            Mathf.LerpAngle(a.x, b.x, 1 - Mathf.Exp(-lambda * dt)),
            Mathf.LerpAngle(a.y, b.y, 1 - Mathf.Exp(-lambda * dt))
            );
    }

    private static List<Transform> GetAllChildrenRecursive(Transform a)
    {
        var listOfChildren = new List<Transform>();

        for (int i = 0; i < a.childCount; i++)
        {
            listOfChildren.Add(a.GetChild(i));
            listOfChildren.AddRange(GetAllChildrenRecursive(a.GetChild(i)));
        }

        return listOfChildren;
    }

    private static List<GameObject> GetAllChildrenRecursive(GameObject a)
    {
        var listOfChildren = new List<GameObject>();

        for (int i = 0; i < a.transform.childCount; i++)
        {
            listOfChildren.Add(a.transform.GetChild(i).gameObject);
            listOfChildren.AddRange(GetAllChildrenRecursive(a.transform.GetChild(i).gameObject));
        }

        return listOfChildren;
    }

    private static List<Component> GetAllComponentsFromList(List<Transform> a, System.Type type)
    {
        var comps = new List<Component>();

        for (int i = 0; i < a.Count; i++)
        {
            var comp = a[i].GetComponent(type);

            if (comp != null)
            {
                comps.Add(comp);
            }
        }

        return comps;
    }

    #endregion Functions

    #region Classes

    //

    #endregion Classes
}