﻿using System;
using System.Collections.Generic;
using System.Linq;
using BasicInfrastructureExtensions.Extensions;
using BasicInfrastructurePersistence.Tests.TestEntities;
using Xunit;
using Xunit2.Should;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BasicInfrastructurePersistence.Tests.Extensions
{
    public class ObjectExtensionsTests
    {
        private readonly TestContrato _contrato;
        public ObjectExtensionsTests()
        {
            _contrato = new TestContrato
            {
                TitularId = 1,
                Contrato_Id = "Contrato_Id",
                NumeroContrato = "01",
                NumeroProposta = "01",
                DateCreated = new DateTime(2017, 1, 1)
            };
        }
        [Fact]
        public void MustGetValueFromObject()
        {
            _contrato.GetValue("TitularId").ShouldBe(1);
            _contrato.GetValue("Contrato_Id").ShouldBe("Contrato_Id");
            _contrato.GetValue("NumeroContrato").ShouldBe("01");
            _contrato.GetValue("NumeroProposta").ShouldBe("01");
            _contrato.GetValue("DateCreated").ShouldBe(new DateTime(2017, 1, 1));

        }
        [Fact]
        public void MustConvertToDictionary()
        {
            var result = _contrato.ToDictionary().ToList();
            var dict = new Dictionary<string, object>
            {
                {"TitularId", 1},
                {"Contrato-Id", "Contrato_Id"},
                {"NumeroContrato", "01"},
                {"NumeroProposta", "01"},
                {"DateCreated", new DateTime(2017, 1, 1)}
            };

            dict.ForEach(x => result.ShouldContain(new KeyValuePair<string, object>(x.Key, x.Value)));
        }
        [Fact]
        public void MustConvertToKeyValuePairs()
        {
            var result = _contrato.ToKeyValuePairs().ToList();
            var list = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("TitularId", 1),
                new KeyValuePair<string, object>("Contrato-Id", "Contrato_Id"),
                new KeyValuePair<string, object>("NumeroContrato", "01"),
                new KeyValuePair<string, object>("NumeroProposta", "01"),
                new KeyValuePair<string, object>("DateCreated", new DateTime(2017, 1, 1))
            }.ToList();

            list.ForEach(x => result.ShouldContain(new KeyValuePair<string, object>(x.Key, x.Value)));
        }

        [Fact]
        public void MustPopulateObject()
        {
            var obj1 = new TestContrato()
            {
                Id = 1,
                Contrato_Id = "string",
                DateCreated = DateTime.Today.AddDays(-10),
                NumeroContrato = "string",
                NumeroProposta = "string",
                TitularId = 2
            };
            var obj2 = new TestContrato2()
            {
                Id = 2,
                NumeroContrato = "Alterado",
                NumeroContrato2 = "Alterado2",
                TitularId = null
            };

            var result = obj1.PopulateProperties(obj2);
            Assert.IsInstanceOfType(result, typeof(TestContrato));

            var resultType = (TestContrato)result;

            resultType.Id.ShouldBe(obj2.Id);
            resultType.NumeroContrato.ShouldBe(obj2.NumeroContrato);

            obj2.NumeroProposta.ShouldBeNull();
            resultType.NumeroProposta.ShouldBeEqual(obj2.NumeroProposta);

            resultType.DateCreated.ShouldBe(obj1.DateCreated);
        }
    }
}
