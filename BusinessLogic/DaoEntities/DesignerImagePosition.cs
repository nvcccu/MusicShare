using System;
using System.Collections.Generic;
using System.Linq;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class DesignerImagePosition : AbstractEntity<DesignerImagePosition> {
        public DesignerImagePosition(string tableName) : base(tableName) {}

        public DesignerImagePosition() : base("DesignerImagePosition") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            ImageId,
            [DbType(typeof (string))]
            Parameters,
            [DbType(typeof (Int32))]
            X,
            [DbType(typeof (Int32))]
            Y
        }

        public int Id { get; set; }
        public int ImageId { get; set; }
        public string Parameters { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Dictionary<int, int> ParseParameters(string parametersString) {
            var parsedParameters = new Dictionary<int, int>();
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
        public DesignerImagePositionDto ToDto() {
            return new DesignerImagePositionDto {
                Id = Id,
                ImageId = ImageId,
                Parameters = ParseParameters(Parameters),
                X = X,
                Y = Y
            };
        }
    }
}