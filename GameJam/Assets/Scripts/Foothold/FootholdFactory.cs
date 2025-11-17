using UnityEngine;

public class FootholdFactory : MonoBehaviour
{
    private static FootholdFactory s_instance = null;
    public static FootholdFactory Instance => s_instance;

    [Header("발판 프리팹")]
    [SerializeField] private GameObject _footholdPrefab;

}
