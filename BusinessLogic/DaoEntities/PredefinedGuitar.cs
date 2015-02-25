using System;
using System.Collections.Generic;
using System.Linq;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class PredefinedGuitar : AbstractEntity<PredefinedGuitar> {
        public PredefinedGuitar(string tableName) : base(tableName) {}

        public PredefinedGuitar() : base("PredefinedGuitar") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            FormId,
            [DbType(typeof (string))]
            ParameterValues
        }

        public int Id { get; set; }
        public int FormId { get; set; }
        public string ParameterValues { get; set; }

        private Dictionary<int, int> ParseParameters(string parametersString) {
            var parsedParameters = new Dictionary<int, int>();
            if (string.IsNullOrEmpty(parametersString)) {
                return parsedParameters;
            }
            if (parametersString.EndsWith(";")) {
                parametersString = parametersString.Substring(0, parametersString.Length - 1);
            }
            var parameterBlocks = parametersString.Split(';');
            foreach (var parameterBlock in parameterBlocks) {
                var parsedParameter = parameterBlock.Split(':');
                if (parsedParameter.Count() != 2) {
                    throw new Exception("Некорректная запись параметров гитары.");
                }
                parsedParameters.Add(Convert.ToInt32(parsedParameter[0]), Convert.ToInt32(parsedParameter[1]));
            }
            return parsedParameters;
        }

        public PredefinedGuitarDto ToDto() {
            return new PredefinedGuitarDto {
                Id = Id,
                FormId = FormId,
                ParameterValues = ParseParameters(ParameterValues)
            };
        }
    }
}