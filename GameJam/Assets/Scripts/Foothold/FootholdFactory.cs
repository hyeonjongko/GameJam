using UnityEngine;

public class FootholdFactory : MonoBehaviour
{
    private static FootholdFactory s_instance = null;
    public static FootholdFactory Instance => s_instance;

    [Header("발판 프리팹")]
    [SerializeField] private GameObject _footholdPrefab;

    [Header("풀링")]
    public int PoolSize = 30;
    private GameObject[] _footholdObjectPool;

    private void Awake()
    {
        if(s_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        s_instance = this;

        PoolInit();

    }

    private void PoolInit()
    {
        _footholdObjectPool = new GameObject[PoolSize];

        for(int i = 0; i < PoolSize; ++i)
        {
            GameObject footholdObject = Instantiate(_footholdPrefab, transform);

            _footholdObjectPool[i] = footholdObject;

            footholdObject.SetActive(false);
        }
    }

    public GameObject MakeFoothold(Vector3 position)
    {
        for(int i = 0;i < PoolSize; ++i)
        {
            GameObject footholdObject = _footholdObjectPool[i];

            //activeInHierarchy : 씬(scene) 내에서 실제로 활성화되어 있는지 아닌지를 알려준다.
            if (footholdObject.activeInHierarchy == false)
            {
                footholdObject.transform.position = position;
                footholdObject.SetActive(true);

                return footholdObject;
            }
        }
        return null;
    }
}
