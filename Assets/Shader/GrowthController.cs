using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{
    public List<MeshRenderer> TreeMeshes;
    public float TimeToGrow = 1;
    public float RefreshRate = 0.05f;
    [Range(0, 1)]
    public float MinGrowth = 0.02f;
    [Range(0, 1)]
    public float MaxGrowth = 0.97f;

    private List<Material> TreeMaterials = new List<Material>();
    private bool isGrown;

    [SerializeField] private GameManagerEventChannelSO _growthEvent;

    private void OnEnable()
    {
        //_growthEvent.GameManagerEvent += GrowTreesTrigger;
    }

    private void OnDisable()
    {
        //_growthEvent.GameManagerEvent -= GrowTreesTrigger;
    }

    private void Start()
    {
        for(int i =-0; i < TreeMeshes.Count; i++)
        {
            for(int j = 0; j < TreeMeshes[i].materials.Length; j++)
            {
                if (TreeMeshes[i].materials[j].HasProperty("Grow_"))
                {
                    TreeMeshes[i].materials[j].SetFloat("Grow_", MinGrowth);
                    TreeMaterials.Add(TreeMeshes[i].materials[j]);
                }
            }
        }
        Invoke("GrowTreesTrigger",1f);
    }

    private void GrowTreesTrigger()
    {
        for(int i = 0; i < TreeMaterials.Count; i++)
        {
            StartCoroutine(GrowCoroutine(TreeMaterials[i]));
            Debug.Log("GrowTreesTrigger activated");
        }
    }
    private IEnumerator GrowCoroutine(Material mat)
    {
        float growValue = mat.GetFloat("Grow_");

        if (!isGrown)
        {
            while(growValue < MaxGrowth)
            {
                growValue += 1/(TimeToGrow/RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(RefreshRate);
            }
        }
        if (growValue >= MaxGrowth)
            isGrown = true;
        else
            isGrown = false;
    }
}
