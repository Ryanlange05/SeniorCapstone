using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(AutoColliderAttach))]
public class AutoColliderAttachEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AutoColliderAttach autoColliderAttach = (AutoColliderAttach)target;

        if (GUILayout.Button("Attach Colliders"))
        {
            autoColliderAttach.AttachColliders();
        }

        if (GUILayout.Button("Remove All Colliders"))
        {
            autoColliderAttach.RemoveColliders();
        }
    }
}
#endif

public class AutoColliderAttach : MonoBehaviour
{
    public CapsuleCollider colliderPrefab;

    [SerializeField]
    private float colliderRadius = 0.5f;
    [SerializeField]
    private float colliderHeight = 2f;

    public void AttachColliders()
    {
        AttachCollidersToGameObject(gameObject);
    }

    public void RemoveColliders()
    {
        RemoveCollidersFromGameObject(gameObject);
    }

    private void AttachCollidersToGameObject(GameObject gameObject)
    {
        Collider existingCollider = gameObject.GetComponent<Collider>();
        if (existingCollider != null)
        {
            Debug.Log($"Collider already attached to {gameObject.name}!");
            return;
        }

        CapsuleCollider newCollider = gameObject.AddComponent<CapsuleCollider>();
        newCollider.direction = colliderPrefab.direction;
        newCollider.center = colliderPrefab.center;
        newCollider.radius = colliderRadius;
        newCollider.height = colliderHeight;
        newCollider.isTrigger = false;

        foreach (Transform child in gameObject.transform)
        {
            AttachCollidersToGameObject(child.gameObject);
        }
    }

    private void RemoveCollidersFromGameObject(GameObject gameObject)
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

        for (int i = 0; i < colliders.Length; i++)
        {
            DestroyImmediate(colliders[i]);
        }
    }
}