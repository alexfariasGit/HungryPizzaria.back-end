﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HungryPizzaria.SDK.AttributeValidation
{
    public class IsValidCNPJ : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string strValue = value as string;

            if (!string.IsNullOrEmpty(strValue))
            {
                string CNPJ = strValue.Replace(".", "");
                CNPJ = CNPJ.Replace("/", "");
                CNPJ = CNPJ.Replace("-", "");

                int[] digitos, soma, resultado;
                int nrDig;
                string ftmt;
                bool[] CNPJOk;

                ftmt = "6543298765432";
                digitos = new int[14];
                soma = new int[2];
                soma[0] = 0;
                soma[1] = 0;
                resultado = new int[2];
                resultado[0] = 0;
                resultado[1] = 0;
                CNPJOk = new bool[2];
                CNPJOk[0] = false;
                CNPJOk[1] = false;

                try
                {
                    for (nrDig = 0; nrDig < 14; nrDig++)
                    {
                        digitos[nrDig] = int.Parse(
                         CNPJ.Substring(nrDig, 1));
                        if (nrDig <= 11)
                            soma[0] += (digitos[nrDig] *
                            int.Parse(ftmt.Substring(
                              nrDig + 1, 1)));
                        if (nrDig <= 12)
                            soma[1] += (digitos[nrDig] *
                            int.Parse(ftmt.Substring(
                              nrDig, 1)));
                    }

                    for (nrDig = 0; nrDig < 2; nrDig++)
                    {
                        resultado[nrDig] = (soma[nrDig] % 11);
                        if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                            CNPJOk[nrDig] = (
                            digitos[12 + nrDig] == 0);

                        else
                            CNPJOk[nrDig] = (
                            digitos[12 + nrDig] == (
                            11 - resultado[nrDig]));

                    }

                    return (CNPJOk[0] && CNPJOk[1]);

                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
