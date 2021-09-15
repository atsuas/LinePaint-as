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
        private SwipeController swipeController;

        private void Start()
        {
            swipeController = new SwipeController();
            swipeController.SetLevelManager(this);

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

        public void MoveBrush(Swipe direction)
        {
            Debug.Log(direction);
        }

        private void Update()
        {
            if (swipeController != null)
            {
                swipeController.OnUpdate();
            }
        }
    }
}
