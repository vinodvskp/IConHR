using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Common validation methods for form fields
/// </summary>
public class FormValidator
{

    public static string ValidateAsSecondaryTxAmount(String Value)
    {
        String errorText = null;
        if (Value.Trim() == String.Empty)
        {
            errorText = "Amount (missing)";
        }
        else
        {
            decimal amountValue;
            if (!decimal.TryParse(Value, out amountValue) || amountValue <= 0 || fractionalPartLength(amountValue) > 2)
            {
                errorText = "Amount (invalid) - [ " + Value + " ]";
            }
        }
        return errorText;
    }

    private static byte fractionalPartLength(decimal amountValue)
    {
        return BitConverter.GetBytes(decimal.GetBits(amountValue)[3])[2];
    }

}