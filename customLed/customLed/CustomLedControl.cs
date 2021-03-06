﻿using customLed;
using customLedStruct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace customLed
{
    /// <summary>
    /// Define the shape of a led
    /// </summary>
    public enum LedStyle : int
    {
        Round = 0,///<!-- Rounded -->
        Square = 1 ///<!-- Square -->
    }

    /// <summary>
    /// Timer tick event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //void m_tTimer_Tick(object sender, EventArgs e)
    //{
    //    MoveItems(m_uiTickCount);
    //    m_uiTickCount++;
    //}


    public partial class CustomLedControl : Control
    {
        int m_iNbLedLines;      ///<!-- Number of led lines                                         --> 
        int m_iNbLedRows;       ///<!-- Number of led rows                                          -->
        double m_dLedSizeCoeff;    ///<!-- Coefficent of the led diameter vs the led cell size: (0->1) --> 
        SolidBrush m_bOnBrush;         ///<!-- Led On brush                                                -->
        SolidBrush m_bOffBrush;        ///<!-- Led Off brush                                               -->
        LedStyle m_lsLedStyle;       ///<!-- Led style                                                   -->
        List<List<LedProperty>> m_llLedPropertyList;///<!-- List of the matrix led                                      -->
        LedMatrixSymbolFontCollection m_fcFontCollection; ///<!-- Font collection of the control                              -->
        List<LedMatrixItem> m_lItemList;        ///<!-- List of items displayed on the control                      -->
        int m_iItemIdCount;     ///<!-- Item Id counter                                             -->
        Timer m_tTimer;
        private BackgroundWorker backgroundWorker1;

        ///<!-- Internal control timer                                      -->
        uint m_uiTickCount;      ///<!-- Timer ticks counting                                        -->

        //-------------------------------//
        //         CONSTRUCTOR           //
        //-------------------------------//
        #region Constuctor

        /// <summary>
        /// Class constructor
        /// </summary>
        public CustomLedControl()
        {
            //---------------------------------------------------
            // Initialisations 

            // Double bufferisation
            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);

            // Size
            m_iNbLedLines = 16;
            m_iNbLedRows = 16;
            m_dLedSizeCoeff = 0.67;

            // Color
            m_bOnBrush = new SolidBrush(Color.Red);
            m_bOffBrush = new SolidBrush(Color.DarkGray);

            // Style
            m_lsLedStyle = LedStyle.Round;

            // Led collection
            m_lItemList = new List<LedMatrixItem>();
            m_llLedPropertyList = new List<List<LedProperty>>();

            // Timer
            m_tTimer = new System.Windows.Forms.Timer();
            m_tTimer.Interval = 70;
            m_tTimer.Tick += new EventHandler(m_tTimer_Tick);
            m_uiTickCount = 0;

            // Id count
            m_iItemIdCount = -1;


            //---------------------------------------------------
            // Construction

            // Place the leds on the control
            SetMatrixSize(m_iNbLedLines, m_iNbLedRows);
        }

        #endregion


        //-------------------------------//
        //         PROPERTIES            //
        //-------------------------------//
        #region Properties

        [Category("Matrix size"), Description("Rows"), DefaultValue(16)]
        public int NbLedRows
        {
            get
            {
                return m_iNbLedRows;
            }
            set
            {
                m_iNbLedRows = value;
                SetMatrixSize(m_iNbLedLines, m_iNbLedRows);
                Invalidate();
            }
        }

        [Category("Matrix size"), Description("Lines"), DefaultValue(16)]
        public int NbLedLines
        {
            get
            {
                return m_iNbLedLines;
            }
            set
            {
                m_iNbLedLines = value;
                SetMatrixSize(m_iNbLedLines, m_iNbLedRows);
                Invalidate();
            }
        }

        [Category("Matrix size"), Description("Size coeff"), DefaultValue(0.66)]
        public double SizeCoeff
        {
            get
            {
                return m_dLedSizeCoeff;
            }
            set
            {
                if ((value < 0) || (value < 1))
                {
                    Invalidate();
                }
                m_dLedSizeCoeff = value;
                SetPositionAndSize();
                Invalidate();
            }
        }

        [Category("Led Color"), Description("On"), DefaultValue("192,45,0")]
        public Color LedOnColor
        {
            get
            {
                return m_bOnBrush.Color;
            }
            set
            {
                m_bOnBrush.Color = value;
                Invalidate();
                Refresh();
            }
        }

        [Category("Led Color"), Description("Off"), DefaultValue("192,111,105")]
        public Color LedOffColor
        {
            get
            {
                return m_bOffBrush.Color;
            }
            set
            {
                m_bOffBrush.Color = value;
                Invalidate();
                Refresh();
            }
        }

        #endregion


        //-------------------------------//
        //        MODIFICATORS           //
        //-------------------------------//
        #region Modificators

        /// <summary>
        /// Set the style of the led
        /// </summary>
        /// <param name="p_lsLedSyle">Led style</param>
        public void SetLedStyle(LedStyle p_lsLedSyle)
        {
            m_lsLedStyle = p_lsLedSyle;
            this.Refresh();
        }

        /// <summary>
        /// Define the number of leds of the control
        /// </summary>
        /// <param name="p_iNbLines">Number of led lines</param>
        /// <param name="p_iNbRows">Number of led rows</param>
        public void SetMatrixSize(int p_iNbLines,
                                  int p_iNbRows)
        {
            // Reset the property list
            m_llLedPropertyList.Clear();

            //---------------------------------------------------
            // Add the led to the control

            // Loop on the lines
            for (int iIdxLine = 0; iIdxLine < p_iNbLines; iIdxLine++)
            {
                List<LedProperty> lLineLedProperty = new List<LedProperty>();

                // Loop on the rows
                for (int iIdxRow = 0; iIdxRow < p_iNbRows; iIdxRow++)
                {
                    LedProperty lpNewProperty = new LedProperty();

                    // Add the led in the line
                    lLineLedProperty.Add(lpNewProperty);
                }

                // Add the line to the control
                m_llLedPropertyList.Add(lLineLedProperty);
            }

            //---------------------------------------------------
            // Define the led of the control

            SetPositionAndSize();

        }

        /// <summary>
        /// Place the led on the control and define their size
        /// </summary>
        private void SetPositionAndSize()
        {
            int iCellSize = 0;
            int iCellSizeFromWidth = 0;
            int iCellSizeFromHeight = 0;
            int iHeightMargin = 0;
            int iWidthMargin = 0;
            int iYLinepos = 0;
            int iXRowpos = 0;

            //---------------------------------------------------
            // Initialisations

            // Select the direction size leader
            iCellSizeFromWidth = this.Width / (m_llLedPropertyList[0].Count);
            iCellSizeFromHeight = this.Height / (m_llLedPropertyList.Count);
            if (iCellSizeFromHeight > iCellSizeFromWidth)
            {
                iCellSize = iCellSizeFromWidth;
            }
            else
            {
                iCellSize = iCellSizeFromHeight;
            }


            // Deduct the margin
          //  iWidthMargin = (this.Width - m_llLedPropertyList[0].Count * iCellSize) / 2;
          //  iHeightMargin = (this.Height - m_llLedPropertyList.Count * iCellSize) / 2;


            //---------------------------------------------------
            // Set position and size

            // Vertical adjustment  
            iYLinepos = iHeightMargin + iCellSize / 2;

            // Loop on the lines
            for (int iIdxLine = 0; iIdxLine < m_llLedPropertyList.Count; iIdxLine++)
            {
                // Horizontal adjustment
                iXRowpos = iWidthMargin + iCellSize / 2;

                // Loop on the rows
                for (int iIdxRow = 0; iIdxRow < m_llLedPropertyList[0].Count; iIdxRow++)
                {
                    // Position
                    m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.X = iXRowpos;
                    m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.Y = iYLinepos;

                    // Size
                    m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius = (int)(iCellSize * m_dLedSizeCoeff / 2);


                    // Updates
                    iXRowpos += iCellSize;
                }

                // Updates
                iYLinepos += iCellSize;
            }

            // Final refresh
            this.Refresh();
        }

        #endregion


        //-------------------------------//
        //           ACCESSOR            //
        //-------------------------------//
        #region Accessor

        /// <summary>
        /// Get the style of the led
        /// </summary>
        /// <returns>Led style</returns>
        public LedStyle GetLedStyle()
        {
            return m_lsLedStyle;
        }

        #endregion


        //-------------------------------//
        //        ITEM MANAGEMENT        //
        //-------------------------------//
        #region ItemMgt

        /// <summary>
        /// Get an item index in the item list by its Id
        /// </summary>
        /// <param name="p_iId">Id of the item</param>
        /// <returns>Index of the item</returns>
        private int GetItemIdxFromId(int p_iId)
        {
            int iIdx = 0;

            // Scan the item list
            foreach (LedMatrixItem lmiItem in m_lItemList)
            {
                // Id match ?
                if (lmiItem.GetId() == p_iId)
                {
                    return iIdx;
                }
                iIdx++;
            }

            // Fail
            return -1;
        }


        /// <summary>
        /// Add an item to the item list
        /// </summary>
        /// <param name="p_bMasterLedOn">Led On definition of the new item</param>
        /// <param name="p_pLocation">Initial position of the new item</param>
        /// <param name="p_dDirection">Direction of the new item</param>
        /// <param name="p_sSpeed">Speed of the new item</param>
        /// <returns>Item Id</returns>
        public int AddItem(bool[,] p_bMasterLedOn,
                           Point p_pLocation,
                           ItemDirection p_dDirection,
                           ItemSpeed p_sSpeed)
        {
            // Updates Id counting
            m_iItemIdCount++;

            // New item
            LedMatrixItem lmiMyNewItem = new LedMatrixItem(m_iItemIdCount,
                                                           p_bMasterLedOn,
                                                           p_pLocation,
                                                           p_dDirection,
                                                           p_sSpeed);

            // Add the item to the list
            m_lItemList.Add(lmiMyNewItem);

            // Return item Id
            return m_iItemIdCount;
        }

        /// <summary>
        /// Add an item built from text to the item list
        /// </summary>
        /// <param name="p_sText">New item text</param>
        /// <param name="p_pLocation">Initial position of the new item</param>
        /// <param name="p_dDirection">Direction of the new item</param>
        /// <param name="p_sSpeed">Speed of the new item</param>
        /// <returns>Item Id</returns>
        public int AddTextItem(string p_sText,
                               Point p_pLocation,
                               ItemDirection p_dDirection,
                               ItemSpeed p_sSpeed)
        {
            // Updates Id counting
            m_iItemIdCount++;

            // New item
            LedMatrixItem lmiMyNewItem = new LedMatrixItem(m_iItemIdCount,
                                                           GetLedOnFromString(p_sText),
                                                           p_pLocation,
                                                           p_dDirection,
                                                           p_sSpeed);

            // Add the item to the list
            m_lItemList.Add(lmiMyNewItem);

            // Return item Id
            return m_iItemIdCount;
        }


        /// <summary>
        /// Set the current location of an item
        /// </summary>
        /// <param name="p_iItemId">Id of the item</param>
        /// <param name="p_pLocation">New current location</param>
        public void SetItemLocation(int p_iItemId,
                                    Point p_pLocation)
        {
            int iItemIdx = -1;

            // Get the item index
            iItemIdx = GetItemIdxFromId(p_iItemId);
            if (iItemIdx == -1)
            {
                return;
            }

            // Set new location


            if (iItemIdx == 0)
            {
                m_lItemList[iItemIdx].SetLocation(new Point(0, 27));

            }

            m_lItemList[iItemIdx].SetLocation(p_pLocation);
            this.Refresh();
        }


        /// <summary>
        /// Set the direction of an item
        /// </summary>
        /// <param name="p_iItemId">Id of the item</param>
        /// <param name="p_dDirection">New direction</param>
        public void SetItemDirection(int p_iItemId,
                                     ItemDirection p_dDirection)
        {
            int iItemIdx = -1;

            // Get the item index
            iItemIdx = GetItemIdxFromId(p_iItemId);
            if (iItemIdx == -1)
            {
                return;
            }

            // Set new direction
            m_lItemList[iItemIdx].SetDirection(p_dDirection);
            return;
        }

        /// <summary>
        /// Set the speed of an item
        /// </summary>
        /// <param name="p_iItemId">Id of the item</param>
        /// <param name="p_sSpeed">New speed</param>
        public void SetItemSpeed(int p_iItemId,
                                 ItemSpeed p_sSpeed)
        {
            int iItemIdx = -1;

            // Get the item index
            iItemIdx = GetItemIdxFromId(p_iItemId);
            if (iItemIdx == -1)
            {
                return;
            }

            // Set new speed
            m_lItemList[iItemIdx].SetSpeed(p_sSpeed);
            return;
        }

        /// <summary>
        /// Set the led On definition of an item from text
        /// </summary>
        /// <param name="p_iItemId">Id of the item</param>
        /// <param name="p_sText">Text to put in the led On definition</param>
        public void SetItemText(int p_iItemId,
                                string p_sText)
        {
            bool[,] bLedOn;
            int iItemIdx = -1;

            // Get the item index
            iItemIdx = GetItemIdxFromId(p_iItemId);
            if (iItemIdx == -1)
            {
                return;
            }

            // Convert text to led On
            bLedOn = GetLedOnFromString(p_sText);

            // Set the new led On definition
            m_lItemList[iItemIdx].SetLedOnArray(bLedOn);
            this.Refresh();
            return;
        }

        /// <summary>
        /// Move the items of the control
        /// </summary>
        /// <param name="p_uiTickCount">Clock ticks counting</param>
        private void MoveItems(uint p_uiTickCount)
        {
            // On each item
            foreach (LedMatrixItem lmiItem in m_lItemList)
            {
                //if (lmiItem.GetId() == 0)
                //{
                //    continue;
                //}
                // Move the item
                lmiItem.MoveItem(p_uiTickCount, m_llLedPropertyList.Count, m_llLedPropertyList[0].Count, m_lItemList);
            }
            this.Refresh();
        }

        /// <summary>
        /// Start the movements of items
        /// </summary>
        /// <param name="i_IdlePeriod">Tick period</param>
        public void StartMove(int i_IdlePeriod)
        {
            m_tTimer.Interval = i_IdlePeriod;
            m_tTimer.Start();
        }

        /// <summary>
        /// Stop the movements of items
        /// </summary>
        public void StopMove()
        {
            m_tTimer.Stop();
        }

        #endregion


        //-------------------------------//
        //       SYBMOLS AND FONTS       //
        //-------------------------------//
        #region Symbols

        /// <summary>
        /// Get the led on array from a char defined in the font collection
        /// </summary>
        /// <param name="p_cSourceChar">Ascci code of the character</param>
        /// <returns>The corresponding led on array</returns>
        private bool[,] GetLedOnFromChar(char p_cSourceChar)
        {
            bool[,] bExclaim = new bool[4, 4];

            // Look in the font collection
            foreach (LedMatrixSymbol lmsSymbol in m_fcFontCollection.lstFontList[0].lstSymbolList)
            {
                // Match ?
                if (p_cSourceChar == lmsSymbol.uiCode)
                {
                    return lmsSymbol.bLedOnMatrix;
                }
            }

            // Unfound symbol
            bExclaim[0, 0] = true;
            bExclaim[0, 2] = true;
            bExclaim[1, 0] = true;
            bExclaim[1, 2] = true;
            bExclaim[3, 0] = true;
            bExclaim[3, 2] = true;
            return bExclaim;
        }

        /// <summary>
        /// Get the led on array from a string
        /// </summary>
        /// <param name="p_sSourceString">String to convert</param>
        /// <returns>The corresponding led on array</returns>
        private bool[,] GetLedOnFromString(string p_sSourceString)
        {
            int iMaxHeightChar = 0;
            int iNbOfLedUsed = 0;
            int iLedCount = 0;
            List<bool[,]> lstLedOnChar = new List<bool[,]>();

            //----------------------------------------------------
            //Get the list of the ledOn array symbols form the string's char

            // Loop on the char
            for (int iIdxChar = 0; iIdxChar < p_sSourceString.Length; iIdxChar++)
            {
                // Get the corresponding array
                lstLedOnChar.Add(GetLedOnFromChar(p_sSourceString[iIdxChar]));

                // Memorize the maximum height size of the chars
                if (lstLedOnChar[lstLedOnChar.Count - 1].GetLength(0) > iMaxHeightChar)
                {
                    iMaxHeightChar = lstLedOnChar[lstLedOnChar.Count - 1].GetLength(0);
                }

                // Updates the nb of led used by the all chars
                iNbOfLedUsed += lstLedOnChar[lstLedOnChar.Count - 1].GetLength(1);
            }

            //---------------------------------------------------
            // Create the return array

            // Allocation
            bool[,] bReturnLedOn = new bool[iMaxHeightChar, iNbOfLedUsed];

            // Loop on the char arrays
            foreach (bool[,] bCurrentLedOn in lstLedOnChar)
            {
                // Loop on lines
                for (int iIdxLine = 0; iIdxLine < bCurrentLedOn.GetLength(0); iIdxLine++)
                {
                    // Loop on rows
                    for (int iIdxRow = 0; iIdxRow < bCurrentLedOn.GetLength(1); iIdxRow++)
                    {
                        // Copy the ledOn
                        bReturnLedOn[iIdxLine, iLedCount + iIdxRow] = bCurrentLedOn[iIdxLine, iIdxRow];
                    }
                }

                // Update
                iLedCount += bCurrentLedOn.GetLength(1);
            }

            // Return
            return bReturnLedOn;
        }


        /// <summary>
        /// Load a font collection from the xml font file in the resources of the project
        /// </summary>
        /// <returns>true for ok; false for fail</returns>
        public bool LoadFontCollectionFromResource(string sResourceName)
        {

            Assembly aAssem = Assembly.GetExecutingAssembly();
            Stream srXmlStream = aAssem.GetManifestResourceStream(sResourceName);
            XmlTextReader rxReaderXml = new XmlTextReader(srXmlStream);

            return LoadFontCollectionFromXmlReader(rxReaderXml);
        }

        /// <summary>
        /// Load a font collection from an xml file
        /// </summary>
        /// <param name="p_sFontCollectionFileName">Font collection file</param>
        /// <returns>true for ok; false for fail</returns>
        public bool LoadFontCollectionFromFile(string p_sFontCollectionFileName)
        {
            XmlTextReader rxReaderXml = new XmlTextReader(p_sFontCollectionFileName);

            return LoadFontCollectionFromXmlReader(rxReaderXml);
        }

        /// <summary>
        /// Load the control font collection from an xml reader stream
        /// </summary>
        /// <param name="p_rxReaderXml">Xml reader stream</param>
        /// <returns>true for ok; false for fail</returns>
        private bool LoadFontCollectionFromXmlReader(XmlTextReader p_rxReaderXml)
        {
            LedMatrixSymbolFontCollection lmsfcReturnCollection;
            List<LedMatrixSymbolFont> lstFontList = new List<LedMatrixSymbolFont>();

            //---------------------------------------------------
            // Initialisations

            // Init the reader
            p_rxReaderXml.WhitespaceHandling = WhitespaceHandling.None;

            //---------------------------------------------------
            // Read the file

            // While there is somthing to read
            while (p_rxReaderXml.Read())
            {
                LedMatrixSymbolFont lmsfNewFont;
                string sFontName;
                List<LedMatrixSymbol> lstSymbolList = new List<LedMatrixSymbol>();


                // End of font ?
                if (p_rxReaderXml.Name != "LedMatrixSymbolFont")
                {
                    // Next one
                    continue;
                }

                // New font
                sFontName = p_rxReaderXml.GetAttribute("FontName");

                // Identify the symbols of the font
                while (p_rxReaderXml.Read())
                {
                    uint uiSmbCode = 0;
                    string sDescription;
                    bool[,] bLedOnMatrix;
                    LedMatrixSymbol lmsNewSymbol;
                    List<LedOnLine> lstLedOnLine = new List<LedOnLine>();

                    // End of sybmols ?
                    if (p_rxReaderXml.Name != "LedMatrixSymbol")
                    {
                        // Next one
                        break;
                    }

                    // New symbol
                    uiSmbCode = Convert.ToUInt32(p_rxReaderXml.GetAttribute("SymbolCode"));
                    sDescription = p_rxReaderXml.GetAttribute("Description");

                    // Identify the Led matrix of the symbol
                    while (p_rxReaderXml.Read())
                    {
                        int iLineNumber = 0;
                        string sLedOn;
                        LedOnLine lolLedOnLine;

                        // End of Led line
                        if (p_rxReaderXml.Name != "LedLine")
                        {
                            // Next one
                            break;
                        }

                        // New Led line
                        iLineNumber = Convert.ToInt32(p_rxReaderXml.GetAttribute("LineNumber"));
                        sLedOn = p_rxReaderXml.GetAttribute("LineLedOn");

                        // Add the line to the list
                        lolLedOnLine = new LedOnLine(iLineNumber, sLedOn);
                        lstLedOnLine.Add(lolLedOnLine);

                    }// Loop ont line processing

                    // Convert the led lines to led matrix
                    bLedOnMatrix = ConvertLedOnLineToLedOnMatrix(lstLedOnLine);

                    // Create and add the symbol
                    lmsNewSymbol = new LedMatrixSymbol(uiSmbCode, sDescription, bLedOnMatrix);
                    lstSymbolList.Add(lmsNewSymbol);

                }// Loop on symbol processing

                // Create and add the font
                lmsfNewFont = new LedMatrixSymbolFont(sFontName, lstSymbolList);
                lstFontList.Add(lmsfNewFont);

            }// Loop on font processing

            // Create the return font collection
            lmsfcReturnCollection = new LedMatrixSymbolFontCollection(lstFontList);

            // Valid font collection ?
            if (lstFontList.Count == 0)
            {
                return false;
            }
            else if (lstFontList[0].lstSymbolList.Count == 0)
            {
                return false;
            }

            // Ok => copy the collection
            m_fcFontCollection = lmsfcReturnCollection;
            return true;
        }

        /// <summary>
        /// Convert a xml ledOn lines to a ledOn bool array
        /// </summary>
        /// <param name="p_lstLedOnLine">List of led led on line to convert</param>
        /// <returns>LedOn line array</returns>
        private bool[,] ConvertLedOnLineToLedOnMatrix(List<LedOnLine> p_lstLedOnLine)
        {
            int iMaxLineSize = 0;
            int iMaxLineNb = 0;
            bool[,] bReturnLedOnMatrix;

            // Get the size of the matrix
            foreach (LedOnLine lolLine in p_lstLedOnLine)
            {
                if (lolLine.sLedOn.Length > iMaxLineSize)
                {
                    iMaxLineSize = lolLine.sLedOn.Length;
                }

                if (lolLine.iLineNo > iMaxLineNb)
                {
                    iMaxLineNb = lolLine.iLineNo;
                }
            }

            // Creation of the return matrix
            bReturnLedOnMatrix = new bool[iMaxLineNb + 1, iMaxLineSize];

            // Build the matix
            foreach (LedOnLine lolLine in p_lstLedOnLine)
            {
                for (int iIdxChar = 0; iIdxChar < lolLine.sLedOn.Length; iIdxChar++)
                {
                    if (lolLine.sLedOn[iIdxChar] == '#')
                    {
                        bReturnLedOnMatrix[lolLine.iLineNo, iIdxChar] = true;
                    }
                }
            }

            // Return the led on matrix
            return bReturnLedOnMatrix;
        }

        #endregion


        //-------------------------------//
        //          EVENTS               //
        //-------------------------------//
        #region Events

        /// <summary>
        /// Timer tick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_tTimer_Tick(object sender, EventArgs e)
        {
            MoveItems(m_uiTickCount);
            m_uiTickCount++;
        }

        /// <summary>
        /// Rezize event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetPositionAndSize();
        }

        /// <summary>
        /// On paint event
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gfx = pe.Graphics;

            // Calling the base class OnPaint
            base.OnPaint(pe);

            // Antialiasing
            gfx.SmoothingMode = SmoothingMode.AntiAlias;

            // Return if non consistant led
            if (m_llLedPropertyList[0][0].m_iRadius == 0)
            {
                return;
            }

            // Loop on the led lines
            for (int iIdxLine = 0; iIdxLine < m_llLedPropertyList.Count; iIdxLine++)
            {
                // Loop on the led row
                for (int iIdxRow = 0; iIdxRow < m_llLedPropertyList[0].Count; iIdxRow++)
                {
                    bool bLedOn = false;

                    // Loop on the display items
                    foreach (LedMatrixItem diDisplayItem in m_lItemList)
                    {
                        // Corresponding point of the item
                        int iLinePtForItem = iIdxLine - diDisplayItem.GetLineOffset();
                        int iRowPtForItem = iIdxRow - diDisplayItem.GetRowOffset();

                        // Valid point ?
                        if ((iLinePtForItem < 0) || (iLinePtForItem >= diDisplayItem.GetMasterLedOn().GetLength(0)) ||
                           (iRowPtForItem < 0) || (iRowPtForItem >= diDisplayItem.GetMasterLedOn().GetLength(1)))
                        {
                            // Not valid => next item
                            continue;
                        }

                        // OR on the cell ledOn
                        bLedOn |= diDisplayItem.GetMasterLedOn()[iLinePtForItem, iRowPtForItem];
                    }

                    // State of the led
                    if (bLedOn == true)
                    {
                        if (m_lsLedStyle == LedStyle.Square)
                        {
                            pe.Graphics.FillRectangle(m_bOnBrush,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.X - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.Y - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1);
                        }
                        else
                        {
                            pe.Graphics.FillPie(m_bOnBrush,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.X - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.Y - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1,
                              0, 360);
                        }
                    }
                    else
                    {
                        if (m_lsLedStyle == LedStyle.Square)
                        {
                            pe.Graphics.FillRectangle(m_bOffBrush,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.X - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.Y - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1,
                            m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1);
                        }
                        else
                        {
                            pe.Graphics.FillPie(m_bOffBrush,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.X - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_ptLocation.Y - m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1,
                              m_llLedPropertyList[iIdxLine][iIdxRow].m_iRadius << 1,
                              0, 360);
                        }
                    }
                }
            }
        }

        #endregion



        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
