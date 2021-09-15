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
            for (int x = 0; x < gridScript.GridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridScript.GridArray.GetLength(1); y++)
                {
                    GameObject block = Instantiate(blockPrefab);
                    block.transform.position = gridScript.GetCellWorldPosition(x, y);
                }
            }
        }

    }

}
