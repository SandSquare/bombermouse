using UnityEngine;

// Credit: https://forum.unity.com/threads/setting-horizontal-fov-orthographic-size-of-the-camera.537911/
[ExecuteInEditMode]
public class AspectCamera : MonoBehaviour
{
    private Camera m_camera;
    private float lastAspect;

    [SerializeField]
    private float verticalOrt = 8f;

    [SerializeField]
    private float m_orthographicSize = 5f;
    public float OrthographicSize
    {
        get { return m_orthographicSize; }
        set
        {
            if (m_orthographicSize != value)
            {
                m_orthographicSize = value;
                RefreshCamera();
            }
        }
    }

    private void OnEnable()
    {
        RefreshCamera();
    }

    private void Update()
    {
        float aspect = m_camera.aspect;
        if (aspect != lastAspect)
            AdjustCamera(aspect);
    }

    public void RefreshCamera()
    {
        if (m_camera == null)
            m_camera = GetComponent<Camera>();

        AdjustCamera(m_camera.aspect);
    }

    private void AdjustCamera(float aspect)
    {
        lastAspect = aspect;

        // Credit: https://forum.unity.com/threads/how-to-calculate-horizontal-field-of-view.16114/#post-2961964
        float _1OverAspect = 1f / aspect;
        var orth =  m_orthographicSize * _1OverAspect;

        m_camera.orthographicSize = (orth + verticalOrt) / 2;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        RefreshCamera();
    }
#endif
}