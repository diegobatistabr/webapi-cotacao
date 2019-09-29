using System;
using System.Collections.Generic;
using System.Text;

namespace seguradora.domain.Utils
{
    public static class DiaUtil
    {        
        public static DateTime ObtemDiaUtil(int diautil)
        {
            var _month = DateTime.Now.AddMonths(1).Month;
            var _year = _month == 1 ? DateTime.Now.AddYears(1).Year : DateTime.Now.Year;
            var dataMesSubsequente = new DateTime(_year, _month, 1);

            var contaDiaUtil = 1;

            while (contaDiaUtil < diautil)
            {
                dataMesSubsequente = dataMesSubsequente.AddDays(1);

                if (!(dataMesSubsequente.DayOfWeek == DayOfWeek.Saturday || dataMesSubsequente.DayOfWeek == DayOfWeek.Sunday || Feriado(dataMesSubsequente) == true))
                {
                    contaDiaUtil = contaDiaUtil + 1;
                }
            }

            return dataMesSubsequente;
        }

        public static bool Feriado(DateTime dt)
        {
            // TODO: Buscas data de Feriados de uma lista pré definida
            // Neste caso não estou listando nenhuma data de feriado. 
            return false;
        }
    }
}
