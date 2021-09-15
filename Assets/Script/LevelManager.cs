using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinePaint
{

    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject blockPrefab;
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private float cellSize;

        private GridScript gridScript;

        private void Start()
        {
            gridScript = new GridScript();
            gridScript.Initialize(width, height, cellSize);

            CreateGrid();
        }

        private void CreateGrid()
        {
            for (var x = 0; x < gridScript.gridArray.GetLength(0); x++)
            {
                for (var x = 0; x < gridScript.gridArray.GetLength(1); x++)
                {
                    GameObject block = Instantiate(blockPrefab);
                }
            }
        }

    }

}
