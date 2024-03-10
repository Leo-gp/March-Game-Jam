using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ContactFilterConfig", fileName = "ContactFilterConfig")]
public class ContactFilterConfig : ScriptableObject
{
    [SerializeField] private ContactFilter2D contactFilter;

    public ContactFilter2D ContactFilter => contactFilter;
}