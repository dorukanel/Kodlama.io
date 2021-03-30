using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding. typeof metodu yeni bir instance (new xyz) almadığı için aynı zamanda aldığı
            //                  bir IValidator değilse diye çalışma esnasında Exception gönderdiğimiz bir kod parçası 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        //validation sadece metodun başında yapıldığı için OnBefore metodunu eziyoruz.
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            /* örnek olarak ProductValidator = _validatorType , onun BaseType'ı AbstractValidator Generic bir yapıda.
            Generic yapının ilk indeksini (0.) entityType'a atadık. Yani bağlantıyı öyle kurduk. |Kod hayran bırakacak kafamda çığır açan bir kod.|  */
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            /* örnek olarak Add() = invocation  argümanlarını gez
              ve validate etmek istediğinle bağlantı kurmasını sağla ve en sonunda her biri için dön.   */

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
