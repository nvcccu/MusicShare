using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Castle.Core.Internal;
using Core.TransportTypes;
using DAO.Enums;
using DAO.Filters.Where;
using DAO.Helpers;

namespace BusinessLogic.Providers {
    public class DerzkieSchiProvider : IDerzkieSchiProvider {
        public Dictionary<ProductTypeDto, Dictionary<PropertyDto, List<PropertyValueDto>>> GetAllProperties() {
            var pruductTypes = new ProductType()
                .Select()
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
            var pruductProperties = new Property()
                .Select()
                .Where(Property.Fields.ProductTypeId, PredicateCondition.In, pruductTypes.Select(p => p.Id))
                .GetData()
                .Select(p => p.ToDto())
                .ToList();
            var propertyValues = new PropertyValue()
                .Select()
                .Where(PropertyValue.Fields.PropertyId, PredicateCondition.In, pruductProperties.Select(pp => pp.Id))
                .GetData()
                .Select(pv => pv.ToDto())
                .ToList();
            return pruductTypes.ToDictionary(p => p,
                p => pruductProperties
                    .Where(pp => pp.ProductTypeId == p.Id)
                    .ToDictionary(pp => pp,
                        pp => propertyValues
                            .Where(pv => pv.PropertyId == pp.Id).ToList()));
        }
        public int? SaveNewProduct(int productTypeId, Dictionary<int, int?> propertyValuePairs, string imageUrl, string name, int price) {
            int? id;
            id = Convert.ToInt32(new Product {
                ProductTypeId = productTypeId,
                ImageUrl = imageUrl,
                Name = name,
                Price = price
            }.Insert());
            foreach (var propertyValuePair in propertyValuePairs) {
                if (propertyValuePair.Value.HasValue) {
                    new ProductPropertyValue {
                        ProductId = id.Value,
                        PropertyId = propertyValuePair.Key,
                        PropertyValueId = propertyValuePair.Value
                    }.Insert();
                }
            }
            return id;
        }
        public List<ProductDto> GetFilteredProducts(int productTypeId, string namePart, Dictionary<int, int> propertyValuePairs) {
            var tmp = new Product()
                .Select()
                .Join(JoinType.Inner, new ProductType(), RetrieveMode.NonRetrieve)
                .On(Product.Fields.ProductTypeId, PredicateCondition.Equal, ProductType.Fields.Id)
                .Join(JoinType.Inner, new ProductPropertyValue(), RetrieveMode.NonRetrieve)
                .On(Product.Fields.Id, PredicateCondition.Equal, ProductPropertyValue.Fields.ProductId)
                .Where(ProductType.Fields.Id, PredicateCondition.Equal, productTypeId)
                .GetData()
                .ToDictionary(p => p.ToDto(), p => p.GetJoinedEntity<ProductPropertyValue>());
            var products = tmp.Select(t => t.Key).GroupBy(t => t.Id).Select(g => g.First()).ToList();
            var propertyValues = tmp.Select(t => t.Value.ToDto()).ToList();
            var productsWithGroupedProperties = products.ToDictionary(p => p, p => propertyValues.Where(t => t.ProductId == p.Id).ToList());
            var ret = new List<ProductDto>();
            foreach (var productWithGroupedProperties in productsWithGroupedProperties) {
                var successByPropertyIds = true;
                foreach (var propertyId in propertyValuePairs.Keys) {
                    if (productWithGroupedProperties.Value.All(p => p.PropertyId != propertyId)) {
                        successByPropertyIds = false;
                    }
                }
                if (successByPropertyIds) {
                    var success = true;
                    foreach (var propertyValuePair in propertyValuePairs) {
                        if (!productWithGroupedProperties.Value.Any(p =>
                                    p.PropertyId == propertyValuePair.Key &&
                                    p.PropertyValueId == propertyValuePair.Value)) {
                            success = false;
                        }
                    }
                    if (success) {
                        ret.Add(productWithGroupedProperties.Key);
                    }
                }
            }
            return ret;    
        }
        public bool UpdateLesson(LessonDto lesson) {
            new Lesson()
                .Update()
                .Set(Lesson.Fields.GuitarTechniqueId, lesson.GuitarTechniqueId)
                .Set(Lesson.Fields.OrderNumber, lesson.OrderNumber)
                .Set(Lesson.Fields.PreviousLessonId, lesson.PreviousLessonId)
                .Set(Lesson.Fields.NextLessonId, lesson.NextLessonId)
                .Set(Lesson.Fields.Description, lesson.Description)
                .Set(Lesson.Fields.Name, lesson.Name)
                .Set(Lesson.Fields.Text, lesson.Text)
                .Set(Lesson.Fields.OriginalLessonUrl, lesson.OriginalLessonUrl)
                .Set(Lesson.Fields.IsModerated, lesson.IsModerated)
                .Where(Lesson.Fields.Id, PredicateCondition.Equal, lesson.Id)
                .ExecuteScalar();
            return true;
        }
        public int CreateLesson(LessonDto lesson) {
            return Convert.ToInt32(new Lesson {
                GuitarTechniqueId = lesson.GuitarTechniqueId,
                OrderNumber = lesson.OrderNumber,
                PreviousLessonId = lesson.PreviousLessonId,
                NextLessonId = lesson.NextLessonId,
                Description = lesson.Description,
                Name = lesson.Name,
                Text = lesson.Text,
                OriginalLessonUrl = lesson.OriginalLessonUrl,
                IsModerated = lesson.IsModerated
            }.Insert());
        }
        public bool UpdateExercise(ExerciseDto exercise) {
            new Exercise()
                .Update()
                .Set(Exercise.Fields.LessonId, exercise.LessonId)
                .Set(Exercise.Fields.Name, exercise.Name)
                .Set(Exercise.Fields.ImageUrl, exercise.ImageUrl)
                .Set(Exercise.Fields.AudioUrl, exercise.AudioUrl)
                .Set(Exercise.Fields.DefaultSpeed, exercise.DefaultSpeed)
                .Set(Exercise.Fields.AuthorAccountId, exercise.AuthorAccountId)
                .Set(Exercise.Fields.IsPublic, exercise.IsPublic)
                .Where(Exercise.Fields.Id, PredicateCondition.Equal, exercise.Id)
                .ExecuteScalar();
            return true;
        }
        public int CreateExercise(ExerciseDto exercise) {
            return Convert.ToInt32(new Exercise {
                LessonId = exercise.LessonId,
                Name = exercise.Name,
                ImageUrl = exercise.ImageUrl,
                AudioUrl = exercise.AudioUrl,
                DefaultSpeed = exercise.DefaultSpeed,
                AuthorAccountId = exercise.AuthorAccountId,
                IsPublic = exercise.IsPublic
            }.Insert());
        }
        public bool IsDerzkiy(int accountId) {
            return new DerzkiyAccount()
                .Select()
                .Where(DerzkiyAccount.Fields.Id, PredicateCondition.Equal, accountId)
                .GetData()
                .Any();
        }
    }
}