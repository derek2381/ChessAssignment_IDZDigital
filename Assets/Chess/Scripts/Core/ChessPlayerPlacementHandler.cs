using System;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;

            // adding positions to the peicesPositions set in the ChessBoardPlacementHandler Class
            string currentPosition = row.ToString() + "#" + column.ToString();
            ChessBoardPlacementHandler.Instance.addCurrentPosition(currentPosition);
        }

        // Return the Row Value of the current peice
        public int getRow()
        {
            return row;
        }

        // Returns the Column Vlue of the current peice
        public int getColumn()
        {
            return column;
        }

        // Checks whether the set Contains the NextPositions or Not
        public bool HasPosition(string nextPosition)
        {
            return ChessBoardPlacementHandler.Instance.HasNextPosition(nextPosition);
        }
    }
}