using System;
using System.Collections.Generic;
using System.Linq;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class DesignerImage : AbstractEntity<DesignerImage> {
        public DesignerImage(string tableName) : base(tableName) {}

        public DesignerImage() : base("DesignerImage") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (string))]
            Parameters,
            [DbType(typeof (string))]
            Url
        }

        public int Id { get; set; }
        public string Parameters { get; set; }
        public string Url { get; set; }


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
                    throw new Exception("Некорректная запись параметров картинки");
                }
                parsedParameters.Add(Convert.ToInt32(parsedParameter[0]), Convert.ToInt32(parsedParameter[1]));
            }
            return parsedParameters;
        }
        public DesignerImageDto ToDto() {
            return new DesignerImageDto {
                Id = Id,
                Parameters = ParseParameters(Parameters),
                Url = Url
            };
        }
    }
}