using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T self;

    public static T Instance
    {
        get
        {
            if (self != null) return self;
            self = FindObjectOfType<T>() as T;
            if (self == null) Debug.LogError($@"インスタンスが存在しません {typeof(T)}");
            return self;
        }
    }

    protected virtual void Awake()
    {
        if (this == Instance) return;

        Destroy(this);
        Debug.LogError($"{nameof(T)} は既に他のGameObjectにアタッチされているため、" +
                        $"コンポーネントを破棄しました.アタッチされているGameObjectは {Instance.gameObject.name} です.");
    }
}
