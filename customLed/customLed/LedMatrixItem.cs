using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customLed
{


    public enum ItemDirection : int
    {
        Up = 0,///<!--Up-->
        Down = 2,///<!--Down-->
        Left = 3,///<!--Left-->
        Right = 4 ///<!--Right-->
    }


    public enum ItemSpeed : int
    {
        Slow = 0,///<!-- Slow -->
        Idle = 1,///<!-- Idle -->
        Fast = 2 ///<!-- Fast -->
    }

    public class LedMatrixItem
    {
        int m_Id;              ///<!-- Id               -->
        bool[,] m_bMasterLedOn;    ///<!-- Led On definiton -->
        Point m_pCurrentLocation;///<!-- Current location -->
        ItemDirection m_dDirection;      ///<!-- Direction        -->
        ItemSpeed m_sSpeed;          ///<!-- Speed            -->


        /// <summary>
        /// Basic constructor
        /// </summary>
        public LedMatrixItem()
        {
            // Initialisations
            m_Id = -1;
            m_pCurrentLocation.X = 0;
            m_pCurrentLocation.Y = 0;
        }

        /// <summary>
        /// Evolved constructor
        /// </summary>
        /// <param name="p_Id">Id code</param>
        /// <param name="p_bMasterLedOn">Led On definition</param>
        /// <param name="p_pInitalLocation">Initial location</param>
        /// <param name="p_dDirection">Direction</param>
        /// <param name="p_sSpeed">Speed</param>
        public LedMatrixItem(int p_Id,
                             bool[,] p_bMasterLedOn,
                             Point p_pInitalLocation,
                             ItemDirection p_dDirection,
                             ItemSpeed p_sSpeed)
        {
            // Initialisations
            m_Id = p_Id;
            m_bMasterLedOn = p_bMasterLedOn;
            m_dDirection = p_dDirection;
            m_sSpeed = p_sSpeed;
            m_pCurrentLocation = p_pInitalLocation;
        }

        /// <summary>
        /// Get the Id of the item
        /// </summary>
        /// <returns>Id of the item</returns>
        public int GetId()
        {
            return m_Id;
        }

        /// <summary>
        /// Get the current line offset of the item (Y pos)
        /// </summary>
        /// <returns>Current line offset of the item</returns>
        public int GetLineOffset()
        {
            return m_pCurrentLocation.Y;
        }

        /// <summary>
        /// Get the current row offset of the item (X pos)
        /// </summary>
        /// <returns>Current row offset of the item</returns>
        public int GetRowOffset()
        {
            return m_pCurrentLocation.X;
        }

        /// <summary>
        /// Get the led On definition of the item
        /// </summary>
        /// <returns>Led On definition of the item</returns>
        public bool[,] GetMasterLedOn()
        {
            return m_bMasterLedOn;
        }

        /// <summary>
        /// Define the led On definition of the item
        /// </summary>
        /// <param name="p_bMasterLedOn">Led On definition</param>
        public void SetLedOnArray(bool[,] p_bMasterLedOn)
        {
            m_bMasterLedOn = p_bMasterLedOn;
        }

        /// <summary>
        /// Define the current location of the item
        /// </summary>
        /// <param name="p_pLocation">Location of the item</param>
        public void SetLocation(Point p_pLocation)
        {
            m_pCurrentLocation = p_pLocation;
        }

        /// <summary>
        /// Define the direction of the item
        /// </summary>
        /// <param name="p_dDirection">Direction of the item</param>
        public void SetDirection(ItemDirection p_dDirection)
        {
            m_dDirection = p_dDirection;
        }

        /// <summary>
        /// Define the speed of the item
        /// </summary>
        /// <param name="p_sSpeed">Speed of the item</param>
        public void SetSpeed(ItemSpeed p_sSpeed)
        {
            m_sSpeed = p_sSpeed;
        }

        /// <summary>
        /// Move the item in the led matrix according to its properties
        /// </summary>
        /// <param name="p_uiTickCount">Clock tick count</param>
        /// <param name="p_iNbCtrlLedLine">Number of lines in the matrix</param>
        /// <param name="p_iNbCtrLedRow">Number of rows in the matrix</param>
        public void MoveItem(uint p_uiTickCount, int p_iNbCtrlLedLine, int p_iNbCtrLedRow, List<LedMatrixItem> p_lItemList)
        {
            int iOffset = 0;

            //---------------------------------------------------
            // Offset computations

            // Define the offset amplitude
            switch (m_sSpeed)
            {
                case ItemSpeed.Slow:
                    {
                        if ((p_uiTickCount % 2) == 0)
                        {
                            iOffset = 1;
                        }
                        break;
                    }
                case ItemSpeed.Idle:
                    {
                        iOffset = 1;
                        break;
                    }
                case ItemSpeed.Fast:
                    {
                        iOffset = 2;
                        break;
                    }

                default:
                    break;
            }

            // Any movement ?
            if (iOffset == 0)
            {
                return;
            }

            if(m_bMasterLedOn.GetLength(1) < p_iNbCtrLedRow)
            {
                return;
            }

            // Applies the offest according to the item direction
            switch (m_dDirection)
            {
                case ItemDirection.Up:
                    m_pCurrentLocation.Y -= iOffset;
                    break;
                case ItemDirection.Down:
                    m_pCurrentLocation.Y += iOffset;
                    break;
                case ItemDirection.Left:
                    m_pCurrentLocation.X -= iOffset;
                    break;
                case ItemDirection.Right:
                    m_pCurrentLocation.X += iOffset;
                    break;
                default:
                    break;
            }


            //---------------------------------------------------
            // Corrections

            // Exit by right
            if (m_pCurrentLocation.X >= p_iNbCtrLedRow)
            { 
                m_pCurrentLocation.X = -m_bMasterLedOn.GetLength(1);
            }
            // Exit by left
            else if (m_pCurrentLocation.X < -m_bMasterLedOn.GetLength(1))
            {
                m_pCurrentLocation.X = p_iNbCtrLedRow - 1;
            }

            // Exit by bottom
            if (m_pCurrentLocation.Y >= p_iNbCtrlLedLine)
            {
                m_pCurrentLocation.Y = -m_bMasterLedOn.GetLength(0);
            }
            // Exit by top-
            else if (m_pCurrentLocation.Y < -m_bMasterLedOn.GetLength(0))
            {
                m_pCurrentLocation.Y = p_iNbCtrlLedLine - 1;
            }
        }

    }
}
