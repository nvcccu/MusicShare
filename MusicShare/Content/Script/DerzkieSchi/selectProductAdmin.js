getSelectProductAdmin = function (data, filterProductUrl, productUrl) {

    var model = {};

    var actualizeActiveProperties = function () {
        if (!model.productType()) {
            return [];
        }
        var activeProperties = model.properties.filter(function (property) {
            return property.productTypeId === model.productType();
        });
        return activeProperties.map(function (property) {
            return {
                property: property,
                propertyValues: model.propertyValues.filter(function (propertyValue) {
                    return propertyValue.propertyId === property.id;
                })
            };
        });
    };
    var productToLowerCase = function(products) {
        return products.map(function(product) {
            return {
                id: product.Id,
                name: product.Name,
                productTypeId: product.ProductTypeId,
                imageUrl: product.ImageUrl,
                price: product.Price
            }
        });
    };

    model.filterProductUrl = filterProductUrl;
    model.productUrl = productUrl;
    model.productTypes = data.productTypes;
    model.properties = data.properties;
    model.propertyValues = data.propertyValues;

    model.productType = ko.observable(null);
    model.productName = ko.observable(null);
    model.productPrice = ko.observable(null);
    model.productImageUrl = ko.observable(null);
    model.activePropertyValueList = ko.computed(actualizeActiveProperties);

    model.products = ko.observableArray(null);

    model.filterProduct = function () {
        var propertyValuePairs = {};
        ko.utils.arrayForEach(model.activePropertyValueList(), function(propertyValue) {
            propertyValuePairs[propertyValue.property.id.toString()] = $('[data-property-id=' + propertyValue.property.id + '] option:selected').val().toString();
        });
        $.ajax({
            url: model.filterProductUrl,
            type: 'POST',
            traditional: true,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                ProductTypeId: model.productType(),
                PropertyValuePairs: propertyValuePairs,
                NamePart: model.productName()
            }),
            success: function (result) {
                model.products(productToLowerCase(result.products));
            },
            error: function (result) {
                alert('error');
            }
        });
        return false;
    };

    return model;
}