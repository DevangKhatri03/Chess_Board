using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }
        
        //This is the constructor for the board class
        public Board (int s)
        {
            //The initial size of the board is defined by the property s
            Size = s;

            // this creates a 2D array of type Cell.
            theGrid = new Cell[Size , Size ];

            //these nested for loops fill the 2D array with cells 
            for (int i = 0; i < Size ; i++)
            {
                for (int j = 0; j < Size ; j++)
                {
                    theGrid[i, j] = new Cell(i , j);
                }

            }
        }

        public void MarkNextLegalMove ( Cell currentCell , string ChessPiece)
        {
            //step 1 - we clear the board totally , so that previous data is not there.

            for ( int i = 0; i < Size ; ++i )
            {
                for ( int j = 0;j < Size ; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i ,j].CurrentlyOccupied = false;
                }
            }

            //step 2 - we will find the legal squares and mark them as legal.

            switch( ChessPiece )
            {
                case "Knight":
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;

                case "King":
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber ].LegalNextMove = true;
                    theGrid[currentCell.RowNumber , currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber ].LegalNextMove = true;
                    theGrid[currentCell.RowNumber , currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;

                case "Rook":
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                default: break;
            }
        } 
    }
}
