getNewProductAdmin = function (data, saveProductUrl) {

    var model = {};

    var actualizeActiveProperties = function () {
        if (model.productType() == undefined) {
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

    model.saveProductUrl = saveProductUrl;
    model.productTypes = data.productTypes;
    model.properties = data.properties;
    model.propertyValues = data.propertyValues;

    model.productType = ko.observable(null);
    model.productName = ko.observable(null);
    model.productPrice = ko.observable(null);
    model.productImageUrl = ko.observable(null);
    model.activePropertyValueList = ko.computed(actualizeActiveProperties);


    model.saveProduct = function () {
        var propertyValuePairs = {};
        ko.utils.arrayForEach(model.activePropertyValueList(), function(propertyValue) {
            propertyValuePairs[propertyValue.property.id.toString()] = $('[data-property-id=' + propertyValue.property.id + '] option:selected').val().toString();
        });
        $.ajax({
            url: model.saveProductUrl,
            type: 'POST',
            traditional: true,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                ProductTypeId: model.productType(),
                PropertyValuePairs: propertyValuePairs,
                ImageUrl: model.productImageUrl(),
                Name: model.productName(),
                Price: model.productPrice()
            }),
            success: function (result) {
                alert('ok');
                model.productName(null);
                model.productPrice(null);
                model.productImageUrl(null);
                model.productType(null);
            },
            error: function (result) {
                alert('error');
            }
        });
        return false;
    };

    return model;
}