using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereCollection {
        public List<FilterWhereBase> FilterWhereBaseCollection { get; set; }
        public List<FilterWhereCollection> FilterWhereCollectionCollection { get; set; }
        private LogicOperator Oper { get; set; }

        public FilterWhereCollection() {
            FilterWhereBaseCollection = new List<FilterWhereBase>();
            FilterWhereCollectionCollection = new List<FilterWhereCollection>();
        }
        public FilterWhereCollection(FilterWhereBase[] filterWhereBaseCollection, FilterWhereCollection[] filterWhereCollectionCollection) {
            Oper = LogicOperator.And;
            FilterWhereBaseCollection = filterWhereBaseCollection != null ? filterWhereBaseCollection.ToList() : null;
            FilterWhereCollectionCollection = filterWhereCollectionCollection != null ? filterWhereCollectionCollection.ToList() : null;
        }
        public FilterWhereCollection(LogicOperator oper, IEnumerable<FilterWhereBase> filterWhereBaseCollection, IEnumerable<FilterWhereCollection> filterWhereCollectionCollection) {
            Oper = oper;
            FilterWhereBaseCollection = filterWhereBaseCollection != null ? filterWhereBaseCollection.ToList() : null;
            FilterWhereCollectionCollection = filterWhereCollectionCollection != null ? filterWhereCollectionCollection.ToList() : null;
        }

        public string TranslateToSql(bool isFirst) {
            var where = String.Empty;
            if (FilterWhereBaseCollection.Any()) {
                if (!isFirst) {
                    where += Oper.GetLogicOperator();
                }
                where += "WHERE (";
                if (FilterWhereBaseCollection != null && FilterWhereBaseCollection.Any()) {
                    where += FilterWhereBaseCollection.First().TranslateToSql(true);
                    for (var i = 1; i < FilterWhereBaseCollection.Count; i++) {
                        where += FilterWhereBaseCollection[i].TranslateToSql(false);
                    }
                }
                if (FilterWhereCollectionCollection != null && FilterWhereCollectionCollection.Any()) {
                    where += FilterWhereCollectionCollection.First().TranslateToSql(false);
                    for (var i = 1; i < FilterWhereCollectionCollection.Count; i++) {
                        where += FilterWhereCollectionCollection[i].TranslateToSql(false);
                    }
                }
                where += ")";
            }
            return where;
        }
    }
}