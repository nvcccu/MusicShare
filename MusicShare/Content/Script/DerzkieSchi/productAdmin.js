﻿getProductAdmin = function (data, addNewProductUrl) {

    var model = {};

    var actualizeActiveProperties = function () {
        if (model.newProductType() == undefined) {
            return {};
        }
        var activeProperties = model.properties.filter(function (property) {
            return property.productTypeId === model.newProductType();
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

    model.addNewProductUrl = addNewProductUrl;

    model.newProductActive = ko.observable(true);
    model.productTypes = data.productTypes;
    model.properties = data.properties;
    model.propertyValues = data.propertyValues;

    model.newProductType = ko.observable(null);
    model.newProductName = ko.observable(null);
    model.newProductPrice = ko.observable(null);
    model.newProductImageUrl = ko.observable(null);
    model.activePropertyValueList = ko.computed(actualizeActiveProperties);

    model.setNewProductActive = function() {
        model.newProductActive(true);
    };
    model.setNewProductInactive = function() {
        model.newProductActive(false);
    };
    model.saveNewProduct = function () {
        var propertyValuePairs = {};
        ko.utils.arrayForEach(model.activePropertyValueList(), function(propertyValue) {
            propertyValuePairs[propertyValue.property.id.toString()] = $('[data-property-id=' + propertyValue.property.id + '] option:selected').val().toString();
        });
        $.ajax({
            url: model.addNewProductUrl,
            type: 'POST',
            traditional: true,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                ProductTypeId: model.newProductType(),
                PropertyValuePairs: propertyValuePairs,
                ImageUrl: model.newProductImageUrl(),
                Name: model.newProductName(),
                Price: model.newProductPrice()
            }),
            success: function (result) {
                alert('ok');
            },
            error: function (result) {
                alert('error');
            }
        });
        return false;
    };

    return model;
}