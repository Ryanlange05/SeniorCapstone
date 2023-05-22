#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class AutoColliderAttach : MonoBehaviour
{
    public GameObject characterRoot;
    public bool includeChildren = true;
    public CapsuleCollider colliderPrefab;
    public float colliderRadius = 0.5f; // Adjust default value as needed
    public float colliderHeight = 2f; // Adjust default value as needed

#if UNITY_EDITOR
    [MenuItem("MyMenu/Attach Colliders")]
    private static void AttachCollidersMenu()
    {
        AutoColliderAttach autoColliderAttach = FindObjectOfType<AutoColliderAttach>();
        if (autoColliderAttach != null)
        {
            autoColliderAttach.AttachColliders();
        }
        else
        {
            Debug.LogWarning("AutoColliderAttach script not found in the scene!");
        }
    }
#endif

    private void Start()
    {
#if UNITY_EDITOR
        AttachColliders();
#endif
    }

    private void AttachColliders()
    {
        if (characterRoot == null)
        {
            Debug.LogError("Character root object reference is missing!");
            return;
        }

        AttachCollidersToGameObject(characterRoot);

        if (includeChildren)
        {
            AttachCollidersToChildren(characterRoot);
        }
    }

   private void AttachCollidersToGameObject(GameObject gameObject)
{
    Collider existingCollider = gameObject.GetComponent<Collider>();
    if (existingCollider != null)
    {
        Debug.Log($"Collider already attached to {gameObject.name}!");
        return;
    }

    foreach (Transform child in gameObject.transform)
    {
        AttachCollidersToGameObject(child.gameObject);
    }
}

      CapsuleCollider newCollider = gameObject.AddComponent<CapsuleCollider>();
    newCollider.direction = colliderPrefab.direction;
    newCollider.center = colliderPrefab.center;
    newCollider.radius = colliderRadius; // Use serialized field for radius
    newCollider.height = colliderHeight; // Use serialized field for height
    newCollider.isTrigger = false;

    void AttachCollidersToChildren(GameObject parentObject)
    {
        foreach (Transform child in parentObject.transform)
        {
            AttachCollidersToGameObject(child.gameObject);
            AttachCollidersToChildren(child.gameObject);
        }
    }

    void CopyColliderData(Collider source, Collider destination)
    {
        if (source is BoxCollider)
        {
            BoxCollider sourceBoxCollider = (BoxCollider)source;
            BoxCollider destinationBoxCollider = (BoxCollider)destination;

            destinationBoxCollider.center = sourceBoxCollider.center;
            destinationBoxCollider.size = sourceBoxCollider.size;
        }
        else if (source is SphereCollider)
        {
            SphereCollider sourceSphereCollider = (SphereCollider)source;
            SphereCollider destinationSphereCollider = (SphereCollider)destination;

            destinationSphereCollider.center = sourceSphereCollider.center;
            destinationSphereCollider.radius = sourceSphereCollider.radius;
        }
        // Add more collider types here if needed
    }
}
}