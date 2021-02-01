using UnityEngine;

public class InputHandler : MonoBehaviour
{
    
    private static bool _previousTouch;
    #region UnityMessages
    
    private void LateUpdate()
    {
        _previousTouch = GetTouch();
    }
    #endregion

    public static float GetHorizontal() => Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);

    public static float GetVertical() => Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);

    public static Vector2 GetAxis()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
#elif UNITY_ANDROID || UNITY_IOS
         return Touch(0).deltaPosition;
#endif
    }

    public static Vector3 Get3DInput() => new Vector3(GetHorizontal(), 0, GetVertical());
    public static Vector2 Get2DInput() => new Vector2(GetHorizontal(), GetVertical());

    public static bool GetTouch()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.GetMouseButton(0);
#elif UNITY_ANDROID || UNITY_IOS
        return Input.touchCount > 0;
#endif
    }

    public static bool GetTouch(int fingerId)
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.GetMouseButton(0);
#elif UNITY_ANDROID || UNITY_IOS
        return (Touch(fingerId).phase == TouchPhase.Began || Touch(fingerId).phase == TouchPhase.Stationary || Touch(fingerId).phase == TouchPhase.Moved);
#endif
    }
    
    public static bool GetTouchDown() => !_previousTouch && GetTouch();

    public static bool GetTouchUp() => _previousTouch && !GetTouch();

    public static Touch Touch(int fingerId)
    {
        foreach (var touch in Input.touches)
        {
            if (touch.fingerId == fingerId)
                return touch;
        }
        return Input.GetTouch(0);
    }
    
    public static Vector2 GetTouchPosition()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.mousePosition;
#elif UNITY_ANDROID || UNITY_IOS
        return Touch(0).position;
#endif
    }
    
    public static Vector2 GetTouchPosition(int fingerId)
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.mousePosition;
#elif UNITY_ANDROID || UNITY_IOS
        return Touch(fingerId).position;
#endif
    }
    
}