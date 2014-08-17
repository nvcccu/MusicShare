using System;

namespace DAO.Attributes {
    public class DbType : Attribute {
        private readonly Type _type;

        public DbType(Type type) {
            _type = type;
        }
    }
}
