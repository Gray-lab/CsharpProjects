using System;
using System.Collections.Generic;
using System.Text;

namespace FieldValidatorAPI
{

    public class CommonFieldValidatorFunctions
    {
        public delegate bool RequiredValidDel(string fieldVal);
        public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
        public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
        public delegate bool PatternMatchDel(string fieldVal, string pattern);
        public delegate bool CompareFieldValidDel(string fieldVal, string fieldValCompare);
        
    }
}