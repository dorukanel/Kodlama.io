using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // buradaki logics Run metoduna gönderdiğimiz  kuralları  temsil eder.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; // ErrorResult'ı döndürür.
                }
            }
            return null; //Bu metoddaki hatayı döndürür.
        }
    }
}
