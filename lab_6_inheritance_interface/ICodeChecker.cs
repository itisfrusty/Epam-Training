using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public interface ICodeChecker
    {

        /// The CodeCheckSyntax() method verifies the correctness of converting one programming language to another.
        bool CodeCheckSyntax(string verificationString, string languageUsed);
    }
}
