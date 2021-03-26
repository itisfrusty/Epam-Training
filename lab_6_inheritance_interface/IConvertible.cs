using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public interface IConvertible
    {
        /// The ConvertToCSharp() method converts the VB code to a C# code.
        string ConvertToCSharp(string vbCode);

        /// The ConvertToCSharp() method converts the C# code to a VB code.
        string ConvertToVB(string csharpCode);
    }
}
