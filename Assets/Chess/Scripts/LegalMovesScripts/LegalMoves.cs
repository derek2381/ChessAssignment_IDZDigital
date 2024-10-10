using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LegalMoves : MonoBehaviour
{
    // Start is called before the first frame update
    abstract protected void CalculateLegalMoves(ChessPlayerPlacementHandler peice);
    abstract protected void HighlightLegalMoves(int row,int column,int rowOffset,int columnOffset, ChessPlayerPlacementHandler peice);
}
