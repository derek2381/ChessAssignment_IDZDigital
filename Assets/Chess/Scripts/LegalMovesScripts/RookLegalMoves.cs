using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookLegalMoves : LegalMoves
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.name == "Rook")
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                ChessPlayerPlacementHandler piece = hit.collider.GetComponent<ChessPlayerPlacementHandler>();
                CalculateLegalMoves(piece);
            }
            else if (hit.collider == null)
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
            }
        }
    }

    // Implement the abstract method to calculate legal moves for the rook
    protected override void CalculateLegalMoves(ChessPlayerPlacementHandler piece)
    {
        int row = piece.getRow();
        int column = piece.getColumn();

        // Rook moves in straight lines (horizontal and vertical)
        int[] rowOffsets = { 1, 0, -1, 0 }; // Down, No change, Up, No change
        int[] columnOffsets = { 0, 1, 0, -1 }; // No change, Right, No change, Left

        // Loop through each direction (up, down, left, right) and highlight the legal moves
        for (int i = 0; i < rowOffsets.Length; i++)
        {
            HighlightLegalMoves(row, column, rowOffsets[i], columnOffsets[i], piece);
        }
    }

    // Implement the abstract method to highlight legal moves for the rook
    protected override void HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler piece)
    {
        string nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();

        // Move in the specified direction until an obstruction or board boundary is encountered
        while ((row + rowOffset) <= 7 && (row + rowOffset) >= 0 && (column + columnOffset) >= 0 && (column + columnOffset) <= 7 && !piece.HasPosition(nextPosition))
        {
            ChessBoardPlacementHandler.Instance.Highlight(row + rowOffset, column + columnOffset);

            // Continue moving in the current direction
            row += rowOffset;
            column += columnOffset;

            nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();
        }
    }
}
