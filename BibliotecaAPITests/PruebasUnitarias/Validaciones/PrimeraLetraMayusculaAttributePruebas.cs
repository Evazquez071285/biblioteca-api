﻿using BibliotecaAPI.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAPITests.PruebasUnitarias.Validaciones
{
    [TestClass]
    public class PrimeraLetraMayusculaAttributePruebas
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("    ")]
        [DataRow(null)]
        [DataRow("Emmanuel")]
        public void IsValid_RetornaExitoso_SiValueNoTieneLaPrimeraLetraMinuscula(string value)
        {
            // Preparación
            var primeraLetraMayusculaAttribute = new PrimeraLetraMayusculaAttribute();
            var validationContext = new ValidationContext(new object());
            
            // Prueba
            var resultado = primeraLetraMayusculaAttribute.GetValidationResult(value, validationContext);

            // Verificación
            //Assert.AreEqual(expected: 1, actual: 2);
            Assert.AreEqual(expected: ValidationResult.Success, actual: resultado);
        }

        [TestMethod]        
        [DataRow("ericka")]
        public void IsValid_RetornaError_SiValueTieneLaPrimeraLetraMinuscula(string value)
        {
            // Preparación
            var primeraLetraMayusculaAttribute = new PrimeraLetraMayusculaAttribute();
            var validationContext = new ValidationContext(new object());

            // Prueba
            var resultado = primeraLetraMayusculaAttribute.GetValidationResult(value, validationContext);

            // Verificación
            //Assert.AreEqual(expected: 1, actual: 2);
            Assert.AreEqual(expected: "La primera letra debe de ser mayúscula", actual: resultado!.ErrorMessage);
        }
    }
}
