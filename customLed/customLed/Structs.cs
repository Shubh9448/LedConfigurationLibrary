using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customLed;

namespace customLedStruct
{
    //-----------------------------------------------------//
    //                   STRUCTS                           //
    //-----------------------------------------------------//

    /// <summary>
    /// Define the composition of a symbol line from the xml "LedLine" node
    /// </summary>
    public struct LedOnLine
    {
        public int iLineNo;///<!-- Line number in the symbol composition-->
        public string sLedOn; ///<!-- String which represents the led On -->

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_iLineNo">Line number</param>
        /// <param name="p_sLedOn">Line string code</param>
        public LedOnLine(int p_iLineNo,
                         string p_sLedOn)
        {
            iLineNo = p_iLineNo;
            sLedOn = p_sLedOn;
        }
    }

    /// <summary>
    /// Define the composition of a symbol
    /// </summary>
    public struct LedMatrixSymbol
    {
        public bool[,] bLedOnMatrix;///<!-- The led On definition         -->
        public string sDescription;///<!-- The description of the symbol -->
        public uint uiCode;      ///<!-- The code of the symbol        -->


        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_uiCode">Code of the symbol</param>
        /// <param name="p_sDescription">Description of the symbol</param>
        /// <param name="p_bLedOnMatrix">Led On definition</param>
        public LedMatrixSymbol(uint p_uiCode,
                               string p_sDescription,
                               bool[,] p_bLedOnMatrix)
        {
            uiCode = p_uiCode;
            sDescription = p_sDescription;
            bLedOnMatrix = p_bLedOnMatrix;
        }
    }

    /// <summary>
    /// Define a whole symbols font
    /// </summary>
    public struct LedMatrixSymbolFont
    {
        public string sName;        ///<!-- The font name                  -->
        public List<LedMatrixSymbol> lstSymbolList;///<!-- The list of symbols in the font -->

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_sName">Font name  </param>
        /// <param name="p_lstSymbolList">List of symbols in the font</param>
        public LedMatrixSymbolFont(string p_sName,
                                   List<LedMatrixSymbol> p_lstSymbolList)
        {
            sName = p_sName;
            lstSymbolList = p_lstSymbolList;
        }
    }

    /// <summary>
    /// Define a collection of symbol fonts
    /// </summary>
    public struct LedMatrixSymbolFontCollection
    {
        public List<LedMatrixSymbolFont> lstFontList;///<!-- The list of fonts -->

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="p_lstFontList">List of fonts</param>
        public LedMatrixSymbolFontCollection(List<LedMatrixSymbolFont> p_lstFontList)
        {
            lstFontList = p_lstFontList;
        }
    }
}
