using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnLegalMoves : LegalMoves
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if(hit.collider != null && hit.collider.name == "Pawn")
            {
                ChessBoardPlacementHandler.Instance.ClearHighlights();
                ChessPlayerPlacementHandler peice = hit.collider.GetComponent<ChessPlayerPlacementHandler>();

                CalculateLegalMoves(peice);
            }
        }
    }

    protected override void CalculateLegalMoves(ChessPlayerPlacementHandler peice)
    {
        int[] rowOffsets = { 1, 2 };
        int[] columnOffsets = { 0, 0};

        int row = peice.getRow();
        int column = peice.getColumn();

        int n = (row == 1) ? 2 : 1;

        for(int i = 0;i < n; i++)
        {
            HighlightLegalMoves(row, column, rowOffsets[i], columnOffsets[i], peice);
        }
    }

    protected override void HighlightLegalMoves(int row, int column, int rowOffset, int columnOffset, ChessPlayerPlacementHandler peice)
    {
        string nextPosition = (row + rowOffset).ToString() + "#" + (column + columnOffset).ToString();
        if ((row+rowOffset) >= 0 && (row + rowOffset) <= 7 && (column + columnOffset) >= 0 && (column + columnOffset) <= 7 && !peice.HasPosition(nextPosition))
        {
            ChessBoardPlacementHandler.Instance.Highlight((row + rowOffset), (column + columnOffset));
        }
    }
}
